using Client.Common.Services.AssetLoader;
using Client.Common.Services.ProgressService;
using Client.Common.Services.ProgressService.Loader;
using Client.Common.Services.ProgressService.Saver;
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
        private readonly IProgressLoader _progressLoader;
        private readonly IProgressSaver _progressSaver;

        public MiniGame1LoadState(ISceneLoader sceneLoader, ILoadingWindowFactory uiFactory, IAssetLoader assetLoader,
            IStartupRunner startupRunner, IProgressLoader progressLoader, IProgressSaver progressSaver)
        {
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
            _assetLoader = assetLoader;
            _startupRunner = startupRunner;
            _progressLoader = progressLoader;
            _progressSaver = progressSaver;
        }

        public async UniTask Enter()
        {
            var loadingWindow = _uiFactory.Create();
            var scene = await LoadScene(loadingWindow);
            await LoadAssets(loadingWindow);
            await LoadProgress(loadingWindow);
            _uiFactory.Destroy(loadingWindow);
            _startupRunner.Run(scene);
        }

        private async UniTask<Scene> LoadScene(LoadingWindow loadingWindow) =>
            await _sceneLoader.LoadSceneAsync(SceneName.MiniGame1, f => loadingWindow.SetProgress(f, 0, 1 / 3f));

        private async UniTask LoadAssets(LoadingWindow loadingWindow) =>
            await _assetLoader.LoadAssets(AssetLabel.MiniGame1, f => loadingWindow.SetProgress(f, 1 / 3f, 2 / 3f));
        
        private async UniTask LoadProgress(LoadingWindow loadingWindow) =>
            await _progressLoader.Load(f => loadingWindow.SetProgress(f, 2 / 3f, 1));
        
        public UniTask Exit()
        {
            _progressSaver.Save();
            return UniTask.CompletedTask;
        }
    }
}