using Client.Common.Services.AssetLoader;
using Client.Common.Services.StateMachine;
using Cysharp.Threading.Tasks;

namespace Client.Hub.Infrastructure.States
{
    public class ProjectLoadState : IState
    {
        private readonly IAssetLoader _assetLoader;
        private readonly IProjectStateMachine _stateMachine;

        public ProjectLoadState(IAssetLoader assetLoader, IProjectStateMachine stateMachine)
        {
            _assetLoader = assetLoader;
            _stateMachine = stateMachine;
        }

        public async UniTask Enter()
        {
            await _assetLoader.LoadProject();
            await _stateMachine.SwitchTo<HubLoadState>();
        }

        public UniTask Exit() => UniTask.CompletedTask;
    }
}