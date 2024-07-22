using Client.Common.Services.ConfigProvider;
using Client.Common.Services.SceneLoader;
using Client.Common.Services.StateMachine;
using Cysharp.Threading.Tasks;

namespace Client.Hub.Infrastructure.States
{
    public class MiniGame1LoadState : IState
    {
        private readonly IConfigProvider _configProvider;
        private readonly ISceneLoader _sceneLoader;

        public MiniGame1LoadState(IConfigProvider configProvider, ISceneLoader sceneLoader)
        {
            _configProvider = configProvider;
            _sceneLoader = sceneLoader;
        }

        public async UniTask Enter()
        {
            var key = _configProvider.Configs.Scenes.MiniGame1Key;
            await _sceneLoader.LoadSceneAsync(key);
        }

        public UniTask Exit() => UniTask.CompletedTask;
    }
}