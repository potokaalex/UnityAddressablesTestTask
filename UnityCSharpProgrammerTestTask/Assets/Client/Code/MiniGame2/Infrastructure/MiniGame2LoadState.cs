using Client.Common.Services.SceneLoader;
using Client.Common.Services.StateMachine;
using Client.Common.UI.Windows.Loading;
using Cysharp.Threading.Tasks;

namespace Client.Code.MiniGame2.Infrastructure
{
    public class MiniGame2LoadState : IState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly ILoadingWindowFactory _uiFactory;

        public MiniGame2LoadState(ISceneLoader sceneLoader, ILoadingWindowFactory uiFactory)
        {
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
        }

        public async UniTask Enter()
        {
            var loadingWindow = _uiFactory.Create();
            await _sceneLoader.LoadSceneAsync(SceneName.MiniGame2, f => loadingWindow.SetProgress(f, 0, 1));
            _uiFactory.Destroy(loadingWindow);
        }

        public UniTask Exit() => UniTask.CompletedTask;
    }
}