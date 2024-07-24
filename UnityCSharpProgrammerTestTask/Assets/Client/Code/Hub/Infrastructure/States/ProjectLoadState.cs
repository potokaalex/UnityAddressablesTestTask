using Client.Common.Infrastructure;
using Client.Common.Services.AssetLoader;
using Client.Common.Services.InputService.Factory;
using Client.Common.Services.Logger;
using Client.Common.Services.StateMachine;
using Client.Common.Services.Updater;
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
        private readonly IUpdater _updater;
        private readonly LoggerByPopup _loggerByPopup;

        public ProjectLoadState(IAssetLoader assetLoader, IStateMachine stateMachine, IGlobalUIFactory uiFactory,
            IInputServiceFactory inputServiceFactory, IUpdater updater, LoggerByPopup loggerByPopup)
        {
            _assetLoader = assetLoader;
            _stateMachine = stateMachine;
            _uiFactory = uiFactory;
            _inputServiceFactory = inputServiceFactory;
            _updater = updater;
            _loggerByPopup = loggerByPopup;
        }

        public async UniTask Enter()
        {
            await _assetLoader.LoadProject();
            _loggerByPopup.Initialize();
            _uiFactory.Initialize();
            _inputServiceFactory.Create();
            await _stateMachine.SwitchTo<HubLoadState>();
        }

        public UniTask Exit()
        {
            _updater.OnProjectExit += () => _stateMachine.SwitchTo<ProjectExitState>().Forget();
            return UniTask.CompletedTask;
        }
    }
}