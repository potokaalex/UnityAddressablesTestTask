using Client.Common.Services.StateMachine;
using Client.Common.UI.Base;
using Client.Hub.Infrastructure.States;
using Client.Hub.UI.Buttons;
using Cysharp.Threading.Tasks;

namespace Client.Hub.UI
{
    public class HubPresenter : IButtonsHandler
    {
        private readonly IProjectStateMachine _stateMachine;

        public HubPresenter(IProjectStateMachine stateMachine) => _stateMachine = stateMachine;

        public void Handle(ButtonBase button)
        {
            if (button.GetBaseType() == ButtonType.Load)
                HandleLoad((LoadButton)button);
        }

        private void HandleLoad(LoadButton button)
        {
            if (button.Type == LoadButtonType.MiniGame1)
                _stateMachine.SwitchTo<MiniGame1LoadState>().Forget();
        }
    }
}