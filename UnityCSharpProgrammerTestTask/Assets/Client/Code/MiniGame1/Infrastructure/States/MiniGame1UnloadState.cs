using Client.Common.Services.AssetLoader;
using Client.Common.Services.StateMachine;
using Cysharp.Threading.Tasks;

namespace Client.MiniGame1.Infrastructure.States
{
    public class MiniGame1UnloadState : IState
    {
        private readonly IAssetLoader _assetLoader;

        public MiniGame1UnloadState(IAssetLoader assetLoader) => _assetLoader = assetLoader;

        public UniTask Enter()
        {
            _assetLoader.UnloadAssets(AssetLabel.MiniGame1);
            return UniTask.CompletedTask;
        }

        public UniTask Exit() => UniTask.CompletedTask;
    }
}