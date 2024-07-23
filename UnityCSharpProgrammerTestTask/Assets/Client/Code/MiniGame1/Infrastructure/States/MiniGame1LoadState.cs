using Client.Common.Services.AssetLoader;
using Client.Common.Services.SceneLoader;
using Client.Common.Services.Startup.Runner;
using Client.Common.Services.StateMachine;
using Client.Common.UI.Windows.Loading;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Client.MiniGame1.Infrastructure.States
{
    public class MiniGame1LoadState : IState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly ILoadingWindowFactory _uiFactory;
        private readonly IAssetLoader _assetLoader;
        private readonly IStartupRunner _startupRunner;

        public MiniGame1LoadState(ISceneLoader sceneLoader, ILoadingWindowFactory uiFactory, IAssetLoader assetLoader,
            IStartupRunner startupRunner)
        {
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
            _assetLoader = assetLoader;
            _startupRunner = startupRunner;
        }

        public async UniTask Enter()
        {
            var loadingWindow = _uiFactory.Create();
            var scene = await LoadScene(loadingWindow);
            await LoadAssets(loadingWindow);
            _uiFactory.Destroy(loadingWindow);
            _startupRunner.Run(scene);
        }

        private async UniTask LoadAssets(LoadingWindow loadingWindow) =>
            await _assetLoader.LoadAssets(AssetLabel.MiniGame1, f => loadingWindow.SetProgress(f, 0.5f, 1));

        private async UniTask<Scene> LoadScene(LoadingWindow loadingWindow) =>
            await _sceneLoader.LoadSceneAsync(SceneName.MiniGame1, f => loadingWindow.SetProgress(f, 0, 0.5f));

        public UniTask Exit() => UniTask.CompletedTask;
    }
}