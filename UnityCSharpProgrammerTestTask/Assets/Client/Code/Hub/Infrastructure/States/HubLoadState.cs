using Client.Common.Services.AssetLoader;
using Client.Common.Services.ConfigProvider;
using Client.Common.Services.SceneLoader;
using Client.Common.Services.Startup.Runner;
using Client.Common.Services.StateMachine;
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

        public HubLoadState(ISceneLoader sceneLoader, IConfigProvider configProvider, IAssetLoader assetLoader, IStartupRunner startupRunner)
        {
            _sceneLoader = sceneLoader;
            _configProvider = configProvider;
            _assetLoader = assetLoader;
            _startupRunner = startupRunner;
        }

        public async UniTask Enter()
        {
            var scene = await LoadScene();

            var hubLabel = _configProvider.Configs.Labels.HubLabel;
            await _assetLoader.LoadAssets(hubLabel);
            _startupRunner.Run(scene);
        }

        public UniTask Exit() => UniTask.CompletedTask;

        private async UniTask<Scene> LoadScene()
        {
            var hubKey = _configProvider.Configs.Scenes.HubKey;
            return await _sceneLoader.LoadSceneAsync(hubKey);
        }
    }
}