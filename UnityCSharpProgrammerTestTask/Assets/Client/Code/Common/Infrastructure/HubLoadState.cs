﻿using Client.Common.Services.AssetLoader;
using Client.Common.Services.SceneLoader;
using Client.Common.Services.Startup.Runner;
using Client.Common.Services.StateMachine;
using Client.Common.UI.Windows.Loading;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Client.Common.Infrastructure
{
    public class HubLoadState : IState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IAssetLoader _assetLoader;
        private readonly IStartupRunner _startupRunner;
        private readonly ILoadingWindowFactory _uiFactory;

        public HubLoadState(ISceneLoader sceneLoader, IAssetLoader assetLoader, IStartupRunner startupRunner, ILoadingWindowFactory uiFactory)
        {
            _sceneLoader = sceneLoader;
            _assetLoader = assetLoader;
            _startupRunner = startupRunner;
            _uiFactory = uiFactory;
        }

        public async UniTask Enter()
        {
            var loadingWindow = _uiFactory.Create();

            var scene = await LoadScene(loadingWindow);
            await LoadAssets(loadingWindow);

            _uiFactory.Destroy(loadingWindow);
            _startupRunner.Run(scene.Item1);
        }

        public UniTask Exit() => UniTask.CompletedTask;

        private async UniTask<(Scene, bool)> LoadScene(LoadingWindow loadingWindow) =>
            await _sceneLoader.LoadSceneAsync(SceneName.Hub, p => loadingWindow.SetProgress(p, 0, 0.5f));

        private async UniTask LoadAssets(LoadingWindow loadingWindow) =>
            await _assetLoader.LoadAssets(AssetLabelType.Hub, p => loadingWindow.SetProgress(p, 0.5f, 1));
    }
}