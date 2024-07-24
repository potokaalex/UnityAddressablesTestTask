using Client.Common.Data.Configs;
using Client.Common.Services.AssetLoader;
using Zenject;

namespace Client.Common.Services.InputService.Factory
{
    public class InputServiceFactory : IInputServiceFactory, IAssetReceiver<ProjectConfig>
    {
        private readonly IInstantiator _instantiator;
        private readonly IInputService _inputService;
        private ProjectConfig _config;

        public InputServiceFactory(IInstantiator instantiator, IInputService inputService)
        {
            _instantiator = instantiator;
            _inputService = inputService;
        }

        public void Create()
        {
            var prefab = _config.InputServiceObjectPrefab;
            var instance = _instantiator.InstantiatePrefabForComponent<InputServiceObject>(prefab);
            _inputService.Initialize(instance);
        }

        public void Receive(ProjectConfig asset) => _config = asset;
    }
}