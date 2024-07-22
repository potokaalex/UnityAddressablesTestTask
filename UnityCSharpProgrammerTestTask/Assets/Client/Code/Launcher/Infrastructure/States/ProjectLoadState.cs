using Client.Common.Services.AssetLoader;
using Client.Common.Services.SceneLoader;
using Client.Common.Services.StateMachine;
using Client.Common.Services.StaticDataProvider;
using Cysharp.Threading.Tasks;

namespace Client.Launcher.Infrastructure.States
{
    public class ProjectLoadState : IState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IStaticDataProvider _staticData;
        private readonly IAssetLoader _assetLoader;

        public ProjectLoadState(ISceneLoader sceneLoader, IStaticDataProvider staticData, IAssetLoader assetLoader)
        {
            _sceneLoader = sceneLoader;
            _staticData = staticData;
            _assetLoader = assetLoader;
        }

        public async UniTask Enter()
        {
            await LoadData();
            await LoadHub();
        }

        public UniTask Exit() => UniTask.CompletedTask;

        private async UniTask LoadHub()
        {
            var hubKey = _staticData.Project.Scenes.HubKey;
            await _sceneLoader.LoadSceneAsync(hubKey);
        }

        private async UniTask LoadData()
        {
            var projectConfig = await _assetLoader.LoadProject();
            _staticData.Initialize(projectConfig);
        }
    }
}