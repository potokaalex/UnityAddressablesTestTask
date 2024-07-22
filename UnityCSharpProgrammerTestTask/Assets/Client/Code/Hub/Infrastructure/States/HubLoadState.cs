using Client.Common.Services.SceneLoader;
using Client.Common.Services.StateMachine;
using Client.Common.Services.StaticDataProvider;
using Cysharp.Threading.Tasks;

namespace Client.Hub.Infrastructure.States
{
    public class HubLoadState : IState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IStaticDataProvider _staticData;

        public HubLoadState(ISceneLoader sceneLoader, IStaticDataProvider staticData)
        {
            _sceneLoader = sceneLoader;
            _staticData = staticData;
        }

        public async UniTask Enter() => await LoadHub();

        public UniTask Exit() => UniTask.CompletedTask;

        private async UniTask LoadHub()
        {
            var hubKey = _staticData.Project.Scenes.HubKey;
            await _sceneLoader.LoadSceneAsync(hubKey);
        }
    }
}