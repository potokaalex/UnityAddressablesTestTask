using Client.Common.Services.AssetLoader;
using Client.Hub.Infrastructure.Data;
using UnityEngine;
using Zenject;

namespace Client.Hub.UI
{
    public class HubUIFactory : IAssetReceiver<HubConfig>
    {
        private readonly IInstantiator _instantiator;
        private HubConfig _config;

        public HubUIFactory(IInstantiator instantiator) => _instantiator = instantiator;

        public void CreateCanvas() => Create(_config.CanvasPrefab);

        public void Receive(HubConfig asset) => _config = asset;

        private void Create<T>(T prefab) where T : MonoBehaviour => _instantiator.InstantiatePrefabForComponent<T>(prefab);
    }
}