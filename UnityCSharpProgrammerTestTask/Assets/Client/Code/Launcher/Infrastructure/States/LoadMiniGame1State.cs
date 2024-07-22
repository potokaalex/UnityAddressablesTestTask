using Client.Common.Services.SceneLoader;
using Client.Common.Services.StateMachine;
using Client.Common.Services.StaticDataProvider;
using Cysharp.Threading.Tasks;

namespace Client.Launcher.Infrastructure.States
{
    public class LoadMiniGame1State : IState
    {
        private readonly IStaticDataProvider _staticData;
        private readonly ISceneLoader _sceneLoader;

        public LoadMiniGame1State(IStaticDataProvider staticData, ISceneLoader sceneLoader)
        {
            _staticData = staticData;
            _sceneLoader = sceneLoader;
        }

        public async UniTask Enter()
        {
            var key = _staticData.Project.Scenes.MiniGame1Key;
            await _sceneLoader.LoadSceneAsync(key);
        }

        public UniTask Exit() => UniTask.CompletedTask;
    }
}