using Client.Common.Services.StateMachine;
using Zenject;

namespace Client.Common.Services.Startup
{
    public class AutoStartupper<T> : IInitializable where T : IState
    {
        private readonly IProjectStateMachine _stateMachine;

        public AutoStartupper(IProjectStateMachine stateMachine) => _stateMachine = stateMachine;

        public void Initialize() => _stateMachine.SwitchTo<T>();
    }
}