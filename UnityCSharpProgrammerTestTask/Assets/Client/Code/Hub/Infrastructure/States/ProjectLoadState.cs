using Client.Common.Services.AssetLoader;
using Client.Common.Services.StateMachine;
using Client.Common.UI.Factories.Global;
using Cysharp.Threading.Tasks;

namespace Client.Hub.Infrastructure.States
{
    public class ProjectLoadState : IState
    {
        private readonly IAssetLoader _assetLoader;
        private readonly IProjectStateMachine _stateMachine;
        private readonly IGlobalUIFactory _uiFactory;

        public ProjectLoadState(IAssetLoader assetLoader, IProjectStateMachine stateMachine, IGlobalUIFactory uiFactory)
        {
            _assetLoader = assetLoader;
            _stateMachine = stateMachine;
            _uiFactory = uiFactory;
        }

        public async UniTask Enter()
        {
            await _assetLoader.LoadProject();
            _uiFactory.Initialize();
            await _stateMachine.SwitchTo<HubLoadState>();
        }

        public UniTask Exit() => UniTask.CompletedTask;
    }
}