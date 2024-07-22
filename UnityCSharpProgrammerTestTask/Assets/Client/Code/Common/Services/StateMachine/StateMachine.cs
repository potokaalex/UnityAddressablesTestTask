using System;

namespace Client.Common.Services.StateMachine
{
    public class StateMachine : IProjectStateMachine
    {
        private readonly StateFactory _factory;
        private IState _currentState;

#if !DEBUG_STATE_MACHINE
        public StateMachine(StateFactory factory) => _factory = factory;
#else
        private readonly bool _isProject;
        public StateMachine(StateFactory factory, bool isProject = false)
        {
            _factory = factory;
            _isProject = isProject;
        }
#endif

        public void SwitchTo<T>() where T : IState => SwitchTo(typeof(T));

        public void SwitchTo(Type type)
        {
            DebugOnExit();
            _currentState?.Exit();
            _currentState = _factory.Create(type);
            DebugOnEnter();

            _currentState.Enter();
        }

        private void DebugOnExit()
        {
#if DEBUG_STATE_MACHINE
            var addition = _isProject ? "-proj" : "";
            if (_currentState != null)
                UnityEngine.Debug.Log($"Exit: {_currentState.GetType().Name}{addition}");
#endif
        }

        private void DebugOnEnter()
        {
#if DEBUG_STATE_MACHINE
            var addition = _isProject ? "-proj" : "";
            UnityEngine.Debug.Log($"Enter: {_currentState.GetType().Name}{addition}");
#endif
        }
    }
}