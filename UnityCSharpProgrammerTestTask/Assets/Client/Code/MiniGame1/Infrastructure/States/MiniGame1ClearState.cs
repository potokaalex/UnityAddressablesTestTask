using Client.Common.Services.AssetLoader;
using Client.Common.Services.SceneLoader;
using Client.Common.Services.StateMachine;
using Cysharp.Threading.Tasks;

namespace Client.MiniGame1.Infrastructure.States
{
    public class MiniGame1ClearState : IState
    {
        private readonly IAssetLoader _assetLoader;
        private readonly ISceneLoader _sceneLoader;

        public MiniGame1ClearState(IAssetLoader assetLoader, ISceneLoader sceneLoader)
        {
            _assetLoader = assetLoader;
            _sceneLoader = sceneLoader;
        }

        public async UniTask Enter()
        {
            await _sceneLoader.ClearScene(SceneName.MiniGame1);
            await _assetLoader.ClearAssets(AssetLabelType.MiniGame1);
        }

        public UniTask Exit() => UniTask.CompletedTask;
    }
}