using Client.Common.Infrastructure;
using Client.Common.Services.AssetLoader;
using Client.Common.Services.InputService.Factory;
using Client.Common.Services.StateMachine;
using Client.Common.UI.Factories.Global;
using Cysharp.Threading.Tasks;

namespace Client.Hub.Infrastructure.States
{
    public class ProjectLoadState : IState
    {
        private readonly IAssetLoader _assetLoader;
        private readonly IStateMachine _stateMachine;
        private readonly IGlobalUIFactory _uiFactory;
        private readonly IInputServiceFactory _inputServiceFactory;

        public ProjectLoadState(IAssetLoader assetLoader, IStateMachine stateMachine, IGlobalUIFactory uiFactory,
            IInputServiceFactory inputServiceFactory)
        {
            _assetLoader = assetLoader;
            _stateMachine = stateMachine;
            _uiFactory = uiFactory;
            _inputServiceFactory = inputServiceFactory;
        }

        public async UniTask Enter()
        {
            await _assetLoader.LoadProject();
            _uiFactory.Initialize();
            _inputServiceFactory.Create();
            await _stateMachine.SwitchTo<HubLoadState>();
        }

        public UniTask Exit() => UniTask.CompletedTask;
    }
}