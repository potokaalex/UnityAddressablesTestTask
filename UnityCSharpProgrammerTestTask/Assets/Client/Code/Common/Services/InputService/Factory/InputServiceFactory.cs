using Client.Common.Services.ConfigProvider;
using Client.Common.Services.Updater;
using Zenject;

namespace Client.Common.Services.InputService.Factory
{
    public class InputServiceFactory : IInputServiceFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IConfigProvider _configProvider;
        private readonly IInputService _inputService;
        private readonly IUpdater _updater;

        public InputServiceFactory(IInstantiator instantiator, IConfigProvider configProvider, IInputService inputService, IUpdater updater)
        {
            _instantiator = instantiator;
            _configProvider = configProvider;
            _inputService = inputService;
            _updater = updater;
        }

        public void Create()
        {
            var prefab = _configProvider.Project.InputServiceObjectPrefab;
            var instance = _instantiator.InstantiatePrefabForComponent<InputServiceObject>(prefab);
            _inputService.Initialize(instance);
        }
    }
}