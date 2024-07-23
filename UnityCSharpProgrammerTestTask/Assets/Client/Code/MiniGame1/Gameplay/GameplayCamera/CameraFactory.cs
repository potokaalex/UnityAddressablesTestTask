using Client.Common.Services.AssetLoader;
using Client.Common.Services.ConfigProvider;
using Zenject;

namespace Client.MiniGame1.Gameplay.GameplayCamera
{
    public class CameraFactory : IInitializable
    {
        public void Initialize() => Create();

        private void Create()
        {
            //_configProvider.MiniGame1
        }
    }
}