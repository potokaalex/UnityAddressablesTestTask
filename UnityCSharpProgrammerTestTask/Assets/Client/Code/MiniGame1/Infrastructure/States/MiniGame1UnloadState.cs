﻿using Client.Common.Infrastructure;
using Client.Common.Services.AssetLoader;
using Client.Common.Services.ProgressService.Saver;
using Client.Common.Services.StateMachine;
using Cysharp.Threading.Tasks;

namespace Client.MiniGame1.Infrastructure.States
{
    public class MiniGame1UnloadState : IState
    {
        private readonly IAssetLoader _assetLoader;
        private readonly IStateMachine _stateMachine;
        private readonly IProgressSaver _progressSaver;

        public MiniGame1UnloadState(IAssetLoader assetLoader, IStateMachine stateMachine, IProgressSaver progressSaver)
        {
            _assetLoader = assetLoader;
            _stateMachine = stateMachine;
            _progressSaver = progressSaver;
        }

        public async UniTask Enter()
        {
            _progressSaver.Save();
            await _stateMachine.SwitchTo<HubLoadState>();
            _assetLoader.UnloadAssets(AssetLabelType.MiniGame1);
        }

        public UniTask Exit() => UniTask.CompletedTask;
    }
}