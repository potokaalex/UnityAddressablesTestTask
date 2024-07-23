using Client.Common.Services.StateMachine;
using Client.Common.Services.StateMachine.Global;
using Client.Common.UI.Button;
using Client.Common.UI.Button.Base;
using Client.Hub.Infrastructure.States;
using Client.Hub.UI.Buttons;
using Cysharp.Threading.Tasks;

namespace Client.Code.MiniGame2.UI
{
    public class MiniGame2Presenter : IButtonsHandler
    {
        private readonly IGlobalStateMachine _stateMachine;

        public MiniGame2Presenter(IGlobalStateMachine stateMachine) => _stateMachine = stateMachine;

        public void Handle(ButtonBase button)
        {
            if (button.GetBaseType() == ButtonType.Load)
                HandleLoad((LoadButton)button);
        }

        private void HandleLoad(LoadButton button)
        {
            if (button.Type == LoadButtonType.Hub)
                _stateMachine.SwitchTo<HubLoadState>().Forget();
        }
    }
}