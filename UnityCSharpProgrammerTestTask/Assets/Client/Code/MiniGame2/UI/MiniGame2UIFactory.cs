using Client.Code.MiniGame2.Data;
using Client.Common.Services.AssetLoader;
using Zenject;

namespace Client.Code.MiniGame2.UI
{
    public class MiniGame2UIFactory : IAssetReceiver<MiniGame2Config>
    {
        private readonly IInstantiator _instantiator;
        private readonly MiniGame2SceneData _sceneData;
        private MiniGame2Config _config;

        public MiniGame2UIFactory(IInstantiator instantiator, MiniGame2SceneData sceneData)
        {
            _instantiator = instantiator;
            _sceneData = sceneData;
        }

        public void CreateWinWindow() => _instantiator.InstantiatePrefab(_config.WinWindowPrefab, _sceneData.UICanvas);

        public void CreateDefeatWindow() => _instantiator.InstantiatePrefab(_config.DefeatWindowPrefab, _sceneData.UICanvas);

        public void Receive(MiniGame2Config asset) => _config = asset;
    }
}