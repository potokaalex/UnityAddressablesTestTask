using Client.Common.Services.AssetLoader;
using Client.MiniGame1.Data;
using Zenject;

namespace Client.MiniGame1.Gameplay.GameplayCamera
{
    public class CameraFactory : IAssetReceiver<MiniGame1Config>
    {
        private readonly IInstantiator _instantiator;
        private readonly CameraController _cameraController;
        private MiniGame1Config _config;

        public CameraFactory(IInstantiator instantiator, CameraController cameraController)
        {
            _instantiator = instantiator;
            _cameraController = cameraController;
        }

        public void Create()
        {
            var instance = _instantiator.InstantiatePrefabForComponent<CameraObject>(_config.CameraPrefab);
            _cameraController.Initialize(instance);
        }

        public void Receive(MiniGame1Config asset) => _config = asset;
    }
}