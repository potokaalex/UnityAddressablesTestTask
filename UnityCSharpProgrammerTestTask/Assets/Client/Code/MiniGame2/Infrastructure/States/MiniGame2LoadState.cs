using Client.Common.Infrastructure;
using Client.Common.Services.AssetLoader;
using Client.Common.Services.ProgressService.Loader;
using Client.Common.Services.SceneLoader;
using Client.Common.Services.Startup.Runner;
using Client.Common.Services.StateMachine;
using Client.Common.UI.Windows.Loading;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Client.Code.MiniGame2.Infrastructure.States
{
    public class MiniGame2LoadState : IState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly ILoadingWindowFactory _uiFactory;
        private readonly IStartupRunner _startupRunner;
        private readonly IAssetLoader _assetLoader;
        private readonly IProgressLoader _progressLoader;
        private readonly IStateMachine _stateMachine;

        public MiniGame2LoadState(ISceneLoader sceneLoader, ILoadingWindowFactory uiFactory, IStartupRunner startupRunner,
            IAssetLoader assetLoader, IProgressLoader progressLoader, IStateMachine stateMachine)
        {
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
            _startupRunner = startupRunner;
            _assetLoader = assetLoader;
            _progressLoader = progressLoader;
            _stateMachine = stateMachine;
        }

        public async UniTask Enter()
        {
            var loadingWindow = _uiFactory.Create();
            var loadSceneResult = await LoadScene(loadingWindow);
            if (loadSceneResult.Item2 && await LoadAssets(loadingWindow))
            {
                await LoadProgress(loadingWindow);
                _startupRunner.Run(loadSceneResult.Item1);
            }
            else
                await _stateMachine.SwitchTo<HubLoadState>();
            
            _uiFactory.Destroy(loadingWindow);
        }

        private async UniTask<(Scene, bool)> LoadScene(LoadingWindow loadingWindow) =>
            await _sceneLoader.LoadSceneAsync(SceneName.MiniGame2, f => loadingWindow.SetProgress(f, 0, 1 / 3f));

        private async UniTask<bool> LoadAssets(LoadingWindow loadingWindow) =>
            await _assetLoader.LoadAssets(AssetLabel.MiniGame2, f => loadingWindow.SetProgress(f, 1 / 3f, 2 / 3f));

        private async UniTask LoadProgress(LoadingWindow loadingWindow) =>
            await _progressLoader.Load(f => loadingWindow.SetProgress(f, 2 / 3f, 1));

        public UniTask Exit() => UniTask.CompletedTask;
    }
}