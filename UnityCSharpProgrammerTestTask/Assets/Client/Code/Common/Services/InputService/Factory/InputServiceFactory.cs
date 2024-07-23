using Client.Common.Services.ConfigProvider;
using Zenject;

namespace Client.Common.Services.InputService
{
    public class InputServiceFactory : IInputServiceFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IConfigProvider _configProvider;
        private readonly IInputService _inputService;

        public InputServiceFactory(IInstantiator instantiator, IConfigProvider configProvider, IInputService inputService)
        {
            _instantiator = instantiator;
            _configProvider = configProvider;
            _inputService = inputService;
        }

        public void Create()
        {
            var prefab = _configProvider.Project.InputServiceObjectPrefab;
            var instance = _instantiator.InstantiatePrefabForComponent<InputServiceObject>(prefab);
            _inputService.Initialize(instance);
        }
    }
}