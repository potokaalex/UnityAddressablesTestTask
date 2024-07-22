﻿using Client.Common.Services.StateMachine;
using Client.Common.UI.Base;
using Client.Hub.Infrastructure.States;
using Client.Hub.UI.Buttons;
using Cysharp.Threading.Tasks;

namespace Client.MiniGame1.UI
{
    public class MiniGame1Presenter : IButtonsHandler
    {
        private readonly IProjectStateMachine _stateMachine;

        public MiniGame1Presenter(IProjectStateMachine stateMachine) => _stateMachine = stateMachine;

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