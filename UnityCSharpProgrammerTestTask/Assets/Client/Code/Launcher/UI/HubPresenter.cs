using Client.Common.Services.StateMachine;
using Client.Common.UI.Base;
using Client.Launcher.Infrastructure.States;
using Client.Launcher.UI.Buttons;
using Cysharp.Threading.Tasks;

namespace Client.Launcher.UI
{
    public class HubPresenter : IButtonsHandler
    {
        private readonly IProjectStateMachine _stateMachine;

        public HubPresenter(IProjectStateMachine stateMachine) => _stateMachine = stateMachine;

        public void Handle(ButtonBase button)
        {
            if (button.GetBaseType() == ButtonType.LoadMiniGame)
                LoadMiniGame1((LoadMiniGameButton)button);
        }

        private void LoadMiniGame1(LoadMiniGameButton button)
        {
            if (button.Type == LoadMiniGameButtonType.MiniGame1)
                _stateMachine.SwitchTo<LoadMiniGame1State>().Forget();
        }
    }
}