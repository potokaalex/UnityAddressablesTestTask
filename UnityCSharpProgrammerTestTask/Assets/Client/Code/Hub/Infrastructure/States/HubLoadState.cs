using Client.Common.Services.AssetLoader;
using Client.Common.Services.ConfigProvider;
using Client.Common.Services.SceneLoader;
using Client.Common.Services.Startup.Runner;
using Client.Common.Services.StateMachine;
using Client.Common.UI.Windows.Loading;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Client.Hub.Infrastructure.States
{
    public class HubLoadState : IState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IConfigProvider _configProvider;
        private readonly IAssetLoader _assetLoader;
        private readonly IStartupRunner _startupRunner;
        private readonly ILoadingWindowFactory _uiFactory;

        public HubLoadState(ISceneLoader sceneLoader, IConfigProvider configProvider, IAssetLoader assetLoader, IStartupRunner startupRunner,
            ILoadingWindowFactory uiFactory)
        {
            _sceneLoader = sceneLoader;
            _configProvider = configProvider;
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
            _startupRunner.Run(scene);
        }

        public UniTask Exit() => UniTask.CompletedTask;

        private async UniTask<Scene> LoadScene(LoadingWindow loadingWindow)
        {
            var hubKey = _configProvider.Project.Scenes.HubKey;
            return await _sceneLoader.LoadSceneAsync(hubKey, p => loadingWindow.SetProgress(p, 0, 0.5f));
        }

        private async UniTask LoadAssets(LoadingWindow loadingWindow)
        {
            var hubLabel = _configProvider.Project.Labels.Hub;
            await _assetLoader.LoadAssets(hubLabel, p => loadingWindow.SetProgress(p, 0.5f, 1));
        }
    }
}