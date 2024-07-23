using System;
using Client.Common.Services.StateMachine.Factory;
using Cysharp.Threading.Tasks;

namespace Client.Common.Services.StateMachine
{
    public class StateMachine : IStateMachine, IDisposable
    {
        private readonly IStateFactory _factory;
        private IState _currentState;

#if !DEBUG_STATE_MACHINE
        public StateMachine(IStateFactory factory) => _factory = factory;
#else
        private readonly bool _isGlobal;
        public StateMachine(IStateFactory factory, bool isGlobal = false)
        {
            _factory = factory;
            _isGlobal = isGlobal;
        }
#endif

        public UniTask SwitchTo<T>() where T : IState => SwitchTo(typeof(T));

        public async UniTask SwitchTo(Type type)
        {
            DebugOnExit();
            if (_currentState != null)
                await _currentState.Exit();

            _currentState = _factory.Create(type);

            DebugOnEnter();
            await _currentState.Enter();
        }

        public void Dispose() => _currentState?.Exit();

        private void DebugOnExit()
        {
#if DEBUG_STATE_MACHINE
            var addition = _isProject ? "-global" : "";
            if (_currentState != null)
                UnityEngine.Debug.Log($"Exit: {_currentState.GetType().Name}{addition}");
#endif
        }

        private void DebugOnEnter()
        {
#if DEBUG_STATE_MACHINE
            var addition = _isProject ? "-global" : "";
            UnityEngine.Debug.Log($"Enter: {_currentState.GetType().Name}{addition}");
#endif
        }
    }
}