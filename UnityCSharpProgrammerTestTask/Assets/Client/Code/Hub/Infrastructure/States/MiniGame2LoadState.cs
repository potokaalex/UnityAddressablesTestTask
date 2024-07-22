using Client.Common.Services.ConfigProvider;
using Client.Common.Services.SceneLoader;
using Client.Common.Services.StateMachine;
using Client.Common.UI.Factories.Global;
using Cysharp.Threading.Tasks;

namespace Client.Hub.Infrastructure.States
{
    public class MiniGame2LoadState : IState
    {
        private readonly IConfigProvider _configProvider;
        private readonly ISceneLoader _sceneLoader;
        private readonly IGlobalUIFactory _uiFactory;

        public MiniGame2LoadState(IConfigProvider configProvider, ISceneLoader sceneLoader, IGlobalUIFactory uiFactory)
        {
            _configProvider = configProvider;
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
        }

        public async UniTask Enter()
        {
            var loadingWindow = _uiFactory.CreateLoadingWindow();
            loadingWindow.Open();
            
            var key = _configProvider.Configs.Scenes.MiniGame2Key;
            await _sceneLoader.LoadSceneAsync(key, f => loadingWindow.SetProgress(f, 0, 1));
            _uiFactory.Destroy(loadingWindow);
        }

        public UniTask Exit() => UniTask.CompletedTask;
    }
}