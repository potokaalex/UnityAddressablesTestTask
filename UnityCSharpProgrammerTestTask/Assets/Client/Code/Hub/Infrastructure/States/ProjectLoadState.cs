using Client.Common.Services.AssetLoader;
using Client.Common.Services.StateMachine;
using Client.Common.Services.StaticDataProvider;
using Cysharp.Threading.Tasks;

namespace Client.Hub.Infrastructure.States
{
    public class ProjectLoadState : IState
    {
        private readonly IStaticDataProvider _staticData;
        private readonly IAssetLoader _assetLoader;
        private readonly IProjectStateMachine _stateMachine;

        public ProjectLoadState(IStaticDataProvider staticData, IAssetLoader assetLoader, IProjectStateMachine stateMachine)
        {
            _staticData = staticData;
            _assetLoader = assetLoader;
            _stateMachine = stateMachine;
        }

        public async UniTask Enter()
        {
            await LoadData();
            await _stateMachine.SwitchTo<HubLoadState>();
        }

        public UniTask Exit() => UniTask.CompletedTask;
        
        private async UniTask LoadData()
        {
            var projectConfig = await _assetLoader.LoadProject();
            _staticData.Initialize(projectConfig);
        }
    }
}