using Client.Common.Services.AssetLoader;
using Client.Common.Services.StateMachine;
using Client.Common.Services.StaticDataProvider;
using Client.Common.Services.UIFactoryService;
using Client.Hub.UI;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Client.Hub.Infrastructure.States
{
    public class HubEnterState : IState
    {
        private readonly IUIFactory _uiFactory;
        private readonly IStaticDataProvider _staticData;
        private readonly IAssetLoader _assetLoader;

        public HubEnterState(IUIFactory uiFactory, IStaticDataProvider staticData, IAssetLoader assetLoader)
        {
            _uiFactory = uiFactory;
            _staticData = staticData;
            _assetLoader = assetLoader;
        }

        public async UniTask Enter()
        {
            var canvasPrefabKey = _staticData.Project.UI.HubCanvasPrefab;
            var canvasPrefab = await _assetLoader.LoadAssetAsync<GameObject>(canvasPrefabKey);
            _uiFactory.Create(canvasPrefab.GetComponent<HubCanvasObject>());
        }

        public UniTask Exit() => UniTask.CompletedTask;
    }
}