using System;
using Client.Common.Services.StateMachine.Factory;
using Cysharp.Threading.Tasks;

namespace Client.Common.Services.StateMachine
{
    public class StateMachine : IStateMachine, IDisposable
    {
        private readonly IStateFactory _factory;
        private IState _currentState;

        public StateMachine(IStateFactory factory) => _factory = factory;

        public UniTask SwitchTo<T>() where T : IState => SwitchTo(typeof(T));

        public async UniTask SwitchTo(Type type)
        {
            await Exit();
            _currentState = _factory.Create(type);
            await Enter();
        }

        private async UniTask Enter()
        {
            DebugOnEnter();
            await _currentState.Enter();
        }

        private async UniTask Exit()
        {
            if (_currentState != null)
            {
                DebugOnExit();
                await _currentState.Exit();
            }
        }

        public void Dispose() => Exit().Forget();

        private protected virtual void DebugOnExit()
        {
#if DEBUG_STATE_MACHINE
            UnityEngine.Debug.Log($"Exit: {CurrentState.GetType().Name}");
#endif
        }

        private protected virtual void DebugOnEnter()
        {
#if DEBUG_STATE_MACHINE
            UnityEngine.Debug.Log($"Enter: {CurrentState.GetType().Name}");
#endif
        }
    }
}