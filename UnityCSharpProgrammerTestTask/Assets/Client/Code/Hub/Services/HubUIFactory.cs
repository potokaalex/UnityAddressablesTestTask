using Client.Common.Services.AssetLoader;
using Client.Common.UI;
using Client.Hub.UI;
using UnityEngine;
using Zenject;

namespace Client.Hub.Services
{
    public class HubUIFactory : IAssetReceiver
    {
        private readonly IInstantiator _instantiator;
        private HubCanvasObject _canvasPrefab;

        public HubUIFactory(IInstantiator instantiator) => _instantiator = instantiator;

        public void CreateCanvas() => Create(_canvasPrefab);

        public void Receive(object asset)
        {
            if (asset.GetType() != typeof(GameObject))
                return;

            var assetGo = (GameObject)asset;
            if (assetGo.TryGetComponent<HubCanvasObject>(out var prefab))
                _canvasPrefab = prefab;
        }

        private void Create<T>(T prefab) where T : MonoBehaviour, IUIElement => _instantiator.InstantiatePrefabForComponent<T>(prefab);
    }
}