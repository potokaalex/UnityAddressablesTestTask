using Client.Common.Services.StateMachine;
using Client.Common.Services.StateMachine.Global;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Client.Common.Services.Startup.Auto
{
    public class AutoStartupperProject<T> : IInitializable where T : IState
    {
        private readonly IGlobalStateMachine _stateMachine;

        public AutoStartupperProject(IGlobalStateMachine stateMachine) => _stateMachine = stateMachine;

        public void Initialize() => _stateMachine.SwitchTo<T>().Forget();
    }
}