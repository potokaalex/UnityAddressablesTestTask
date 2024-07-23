using Client.Common.Services.ConfigProvider;
using Client.Common.Services.SceneLoader;
using Client.Common.Services.StateMachine;
using Client.Common.UI.Factories.Global;
using Client.Common.UI.Windows.Loading;
using Cysharp.Threading.Tasks;

namespace Client.Hub.Infrastructure.States
{
    public class MiniGame1LoadState : IState
    {
        private readonly IConfigProvider _configProvider;
        private readonly ISceneLoader _sceneLoader;
        private readonly ILoadingWindowFactory _uiFactory;

        public MiniGame1LoadState(IConfigProvider configProvider, ISceneLoader sceneLoader, ILoadingWindowFactory uiFactory)
        {
            _configProvider = configProvider;
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
        }

        public async UniTask Enter()
        {
            var loadingWindow = _uiFactory.Create();
            var key = _configProvider.Project.Scenes.MiniGame1Key;
            await _sceneLoader.LoadSceneAsync(key, f => loadingWindow.SetProgress(f, 0, 1));
            _uiFactory.Destroy(loadingWindow);
        }

        public UniTask Exit() => UniTask.CompletedTask;
    }
}