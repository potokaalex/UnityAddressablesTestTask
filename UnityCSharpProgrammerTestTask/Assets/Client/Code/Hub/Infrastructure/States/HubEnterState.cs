using Client.Common.Services.StateMachine;
using Cysharp.Threading.Tasks;

namespace Client.Hub.Infrastructure.States
{
    public class HubEnterState : IState
    {
        public UniTask Enter() => UniTask.CompletedTask;

        public UniTask Exit() => UniTask.CompletedTask;
    }
}