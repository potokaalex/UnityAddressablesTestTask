﻿using Client.Code.MiniGame2.Infrastructure.States;
using Client.Common.Services.StateMachine.Global;
using Client.Common.UI.Button.Base;
using Client.Common.UI.Button.Load;
using Client.Hub.UI.Buttons.Unload;
using Client.MiniGame1.Infrastructure.States;
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

            if (button.GetBaseType() == ButtonType.Unload)
                HandleUnload((UnloadButton)button);
        }

        private void HandleUnload(UnloadButton button)
        {
            if (button.Type == UnloadButtonType.MiniGame1)
                _stateMachine.SwitchTo<MiniGame1ClearState>().Forget();
            else if (button.Type == UnloadButtonType.MiniGame2)
                _stateMachine.SwitchTo<MiniGame2ClearState>().Forget();
        }

        private void HandleLoad(LoadButton button)
        {
            if (button.Type == LoadButtonType.MiniGame1)
                _stateMachine.SwitchTo<MiniGame1LoadState>().Forget();
            else if (button.Type == LoadButtonType.MiniGame2)
                _stateMachine.SwitchTo<MiniGame2LoadState>().Forget();
        }
    }
}