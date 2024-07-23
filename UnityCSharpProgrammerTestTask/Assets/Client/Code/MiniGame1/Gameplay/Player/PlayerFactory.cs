using Client.Common.Services.AssetLoader;
using Client.Common.Services.Updater;
using Client.MiniGame1.Data;
using Client.MiniGame1.Gameplay.Player.UI;
using Zenject;

namespace Client.MiniGame1.Gameplay.Player
{
    public class PlayerFactory : IAssetReceiver<MiniGame1Config>
    {
        private readonly IInstantiator _instantiator;
        private readonly PlayerPresenter _presenter;
        private readonly IUpdater _updater;
        private readonly PlayerController _controller;
        private MiniGame1Config _config;

        public PlayerFactory(IInstantiator instantiator, PlayerPresenter presenter, IUpdater updater, PlayerController controller)
        {
            _instantiator = instantiator;
            _presenter = presenter;
            _updater = updater;
            _controller = controller;
        }

        public void Create()
        {
            var prefab = _config.PlayerCanvasPrefab;
            var instance = _instantiator.InstantiatePrefabForComponent<PlayerCanvas>(prefab);
            _presenter.Initialize(instance);
            _updater.OnUpdate += _controller.OnUpdate;
        }

        public void Destroy() => _updater.OnUpdate -= _controller.OnUpdate;

        public void Receive(MiniGame1Config asset) => _config = asset;
    }
}