using Client.Common.Services.AssetLoader;
using Client.Hub.Data;
using UnityEngine;
using Zenject;

namespace Client.Hub.UI.Factory
{
    public class HubUIFactory : IAssetReceiver<HubConfig>, IHubUIFactory
    {
        private readonly IInstantiator _instantiator;
        private HubConfig _config;

        public HubUIFactory(IInstantiator instantiator) => _instantiator = instantiator;

        public void CreateCanvas() => Create(_config.CanvasPrefab);

        public void Receive(HubConfig asset) => _config = asset;

        private void Create<T>(T prefab) where T : MonoBehaviour => _instantiator.InstantiatePrefabForComponent<T>(prefab);
    }
}