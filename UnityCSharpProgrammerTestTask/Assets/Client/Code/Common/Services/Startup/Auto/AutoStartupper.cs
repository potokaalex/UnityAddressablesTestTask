using Client.Common.Services.StateMachine;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Client.Common.Services.Startup.Auto
{
    public class AutoStartupper<T> : IInitializable where T : IState
    {
        private readonly IStateMachine _stateMachine;

        public AutoStartupper(IStateMachine stateMachine) => _stateMachine = stateMachine;

        public void Initialize() => _stateMachine.SwitchTo<T>().Forget();
    }
}