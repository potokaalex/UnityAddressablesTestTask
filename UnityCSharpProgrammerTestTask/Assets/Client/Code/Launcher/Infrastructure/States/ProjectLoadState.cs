using System.Threading.Tasks;
using Client.Common.Services.AssetLoader;
using Client.Common.Services.SceneLoader;
using Client.Common.Services.Startup;
using Client.Common.Services.StateMachine;
using Client.Common.Services.StaticDataProvider;
using UnityEngine.SceneManagement;

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

        public async void Enter()
        {
            await LoadData();
            var scene = await LoadScene();
            _sceneLoader.FindInScene<IStartuper>(scene.name).Startup();
        }

        private async Task<Scene> LoadScene()
        {
            var hubKey = _staticData.Project.Scenes.HubKey;
            var scene = await _sceneLoader.LoadSceneAsync(hubKey);
            return scene;
        }

        private async Task LoadData()
        {
            var projectConfig = await _assetLoader.LoadProject();
            _staticData.Initialize(projectConfig);
        }
    }
}