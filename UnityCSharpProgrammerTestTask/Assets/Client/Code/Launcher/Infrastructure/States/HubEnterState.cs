using Client.Common.Services.StateMachine;
using Cysharp.Threading.Tasks;

namespace Client.Launcher.Infrastructure.States
{
    public class HubEnterState : IState
    {
        public UniTask Enter() => UniTask.CompletedTask;

        public UniTask Exit() => UniTask.CompletedTask;
    }
}