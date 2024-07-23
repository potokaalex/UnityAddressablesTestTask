using Client.Common.Services.StateMachine;
using Client.Common.Services.StateMachine.Global;
using Client.Common.UI.Button;
using Client.Common.UI.Button.Base;
using Client.Hub.Infrastructure.States;
using Client.Hub.UI.Buttons;
using Cysharp.Threading.Tasks;

namespace Client.Hub.UI
{
    public class HubPresenter : IButtonsHandler
    {
        private readonly IGlobalStateMachine _stateMachine;

        public HubPresenter(IGlobalStateMachine stateMachine) => _stateMachine = stateMachine;

        public void Handle(ButtonBase button)
        {
            if (button.GetBaseType() == ButtonType.Load)
                HandleLoad((LoadButton)button);
        }

        private void HandleLoad(LoadButton button)
        {
            if (button.Type == LoadButtonType.MiniGame1)
                _stateMachine.SwitchTo<MiniGame1LoadState>().Forget();
            else if(button.Type == LoadButtonType.MiniGame2)
                _stateMachine.SwitchTo<MiniGame2LoadState>().Forget();
        }
    }
}