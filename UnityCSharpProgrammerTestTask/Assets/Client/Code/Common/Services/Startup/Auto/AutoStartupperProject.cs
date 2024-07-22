using Client.Common.Services.StateMachine;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Client.Common.Services.Startup.Auto
{
    public class AutoStartupperProject<T> : IInitializable where T : IState
    {
        private readonly IProjectStateMachine _stateMachine;

        public AutoStartupperProject(IProjectStateMachine stateMachine) => _stateMachine = stateMachine;

        public void Initialize() => _stateMachine.SwitchTo<T>().Forget();
    }
}