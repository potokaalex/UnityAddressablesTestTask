using Client.Common.Services.StateMachine;
using Client.Hub.UI;
using Cysharp.Threading.Tasks;

namespace Client.Hub.Infrastructure.States
{
    public class HubEnterState : IState
    {
        private readonly HubUIFactory _uiFactory;

        public HubEnterState(HubUIFactory uiFactory) => _uiFactory = uiFactory;

        public UniTask Enter()
        {
            _uiFactory.CreateCanvas();
            return UniTask.CompletedTask;
        }

        public UniTask Exit() => UniTask.CompletedTask;
    }
}