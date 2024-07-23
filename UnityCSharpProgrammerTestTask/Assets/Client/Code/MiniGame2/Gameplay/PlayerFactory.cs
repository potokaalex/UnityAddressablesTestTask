using Client.Code.MiniGame2.Data;
using Client.Common.Services.AssetLoader;
using Client.Common.Services.Updater;
using Zenject;

namespace Client.Code.MiniGame2.Gameplay
{
    public class PlayerFactory : IAssetReceiver<MiniGame2Config>
    {
        private readonly IInstantiator _instantiator;
        private readonly MiniGame2SceneData _sceneData;
        private readonly PlayerController _playerController;
        private readonly IUpdater _updater;
        private MiniGame2Config _config;

        public PlayerFactory(IInstantiator instantiator, MiniGame2SceneData sceneData, PlayerController playerController, IUpdater updater)
        {
            _instantiator = instantiator;
            _sceneData = sceneData;
            _playerController = playerController;
            _updater = updater;
        }

        public void Create()
        {
            var instance = _instantiator.InstantiatePrefabForComponent<PlayerObject>(_config.PlayerPrefab, _sceneData.PlayerSpawnPoint);
            _playerController.Initialize(instance);
            _updater.OnUpdate += _playerController.OnUpdate;
            _updater.OnFixedUpdate += _playerController.OnFixedUpdate;
        }

        public void Destroy()
        {
            _updater.OnUpdate -= _playerController.OnUpdate;
            _updater.OnFixedUpdate -= _playerController.OnFixedUpdate;
        }
        
        public void Receive(MiniGame2Config asset) => _config = asset;
    }
}