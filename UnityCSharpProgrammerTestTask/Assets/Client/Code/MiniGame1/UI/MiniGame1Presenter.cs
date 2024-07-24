using Client.Common.Infrastructure;
using Client.Common.Services.StateMachine;
using Client.Common.Services.StateMachine.Global;
using Client.Common.UI.Button;
using Client.Common.UI.Button.Base;
using Client.Common.UI.Button.Load;
using Client.MiniGame1.Infrastructure.States;
using Cysharp.Threading.Tasks;

namespace Client.MiniGame1.UI
{
    public class MiniGame1Presenter : IButtonsHandler
    {
        private readonly IGlobalStateMachine _stateMachine;

        public MiniGame1Presenter(IGlobalStateMachine stateMachine) => _stateMachine = stateMachine;

        public void Handle(ButtonBase button)
        {
            if (button.GetBaseType() == ButtonType.Load)
                HandleLoad((LoadButton)button);
        }

        private void HandleLoad(LoadButton button)
        {
            if (button.Type == LoadButtonType.Hub)
                _stateMachine.SwitchTo<MiniGame1ExitState>().Forget();
        }
    }
}