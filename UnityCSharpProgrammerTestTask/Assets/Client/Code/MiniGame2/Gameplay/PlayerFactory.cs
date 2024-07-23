using Client.Code.MiniGame2.Data;
using Client.Common.Services.AssetLoader;
using Zenject;

namespace Client.Code.MiniGame2.Gameplay
{
    public class PlayerFactory : IAssetReceiver<MiniGame2Config>
    {
        private readonly IInstantiator _instantiator;
        private readonly MiniGame2SceneData _sceneData;
        private MiniGame2Config _config;

        public PlayerFactory(IInstantiator instantiator, MiniGame2SceneData sceneData)
        {
            _instantiator = instantiator;
            _sceneData = sceneData;
        }

        public void Create()
        {
            var instance = _instantiator.InstantiatePrefabForComponent<PlayerObject>(_config.PlayerPrefab, _sceneData.PlayerSpawnPoint);
        }

        public void Receive(MiniGame2Config asset) => _config = asset;
    }
}