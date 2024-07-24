using Client.Common.Services.AssetLoader;
using Client.Common.Services.SceneLoader;
using Client.Common.Services.StateMachine;
using Cysharp.Threading.Tasks;

namespace Client.Code.MiniGame2.Infrastructure.States
{
    public class MiniGame2ClearState : IState
    {
        private readonly IAssetLoader _assetLoader;
        private readonly ISceneLoader _sceneLoader;

        public MiniGame2ClearState(IAssetLoader assetLoader, ISceneLoader sceneLoader)
        {
            _assetLoader = assetLoader;
            _sceneLoader = sceneLoader;
        }

        public async UniTask Enter()
        {
            await _sceneLoader.ClearScene(SceneName.MiniGame2);
            await _assetLoader.ClearAssets(AssetLabelType.MiniGame2);
        }

        public UniTask Exit() => UniTask.CompletedTask;
    }
}