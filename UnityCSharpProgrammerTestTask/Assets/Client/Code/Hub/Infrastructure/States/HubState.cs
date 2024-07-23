using Client.Common.Services.StateMachine;
using Client.Hub.UI.Factory;
using Cysharp.Threading.Tasks;

namespace Client.Hub.Infrastructure.States
{
    public class HubState : IState
    {
        private readonly IHubUIFactory _uiFactory;

        public HubState(IHubUIFactory uiFactory) => _uiFactory = uiFactory;

        public UniTask Enter()
        {
            _uiFactory.CreateCanvas();
            return UniTask.CompletedTask;
        }

        public UniTask Exit() => UniTask.CompletedTask;
    }
}