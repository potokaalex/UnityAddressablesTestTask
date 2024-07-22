using Client.Common.Services.AssetLoader;
using Client.Common.Services.ConfigProvider;
using Client.Common.Services.SceneLoader;
using Client.Common.Services.Startup.Runner;
using Client.Common.Services.StateMachine;
using Client.Common.UI.Factories.Global;
using Client.Common.UI.Windows;
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
        private readonly IGlobalUIFactory _uiFactory;

        public HubLoadState(ISceneLoader sceneLoader, IConfigProvider configProvider, IAssetLoader assetLoader, IStartupRunner startupRunner,
            IGlobalUIFactory uiFactory)
        {
            _sceneLoader = sceneLoader;
            _configProvider = configProvider;
            _assetLoader = assetLoader;
            _startupRunner = startupRunner;
            _uiFactory = uiFactory;
        }

        public async UniTask Enter()
        {
            var loadingWindow = _uiFactory.CreateLoadingWindow();
            loadingWindow.Open();

            var scene = await LoadScene(loadingWindow);
            await LoadAssets(loadingWindow);

            _uiFactory.Destroy(loadingWindow);
            _startupRunner.Run(scene);
        }

        public UniTask Exit() => UniTask.CompletedTask;

        private async UniTask<Scene> LoadScene(LoadingWindow loadingWindow)
        {
            var hubKey = _configProvider.Configs.Scenes.HubKey;
            return await _sceneLoader.LoadSceneAsync(hubKey, p => loadingWindow.SetProgress(p, 0, 0.5f));
        }

        private async UniTask LoadAssets(LoadingWindow loadingWindow)
        {
            var hubLabel = _configProvider.Configs.Labels.Hub;
            await _assetLoader.LoadAssets(hubLabel, p => loadingWindow.SetProgress(p, 0.5f, 1));
        }
    }
}