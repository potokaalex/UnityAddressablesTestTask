using Client.Common.Services.StateMachine;
using Client.Common.Services.StateMachine.Global;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Client.Common.Services.Startup.Auto
{
    public class AutoStartupperGlobal<T> : IInitializable where T : IState
    {
        private readonly IGlobalStateMachine _stateMachine;

        public AutoStartupperGlobal(IGlobalStateMachine stateMachine) => _stateMachine = stateMachine;

        public void Initialize() => _stateMachine.SwitchTo<T>().Forget();
    }
}