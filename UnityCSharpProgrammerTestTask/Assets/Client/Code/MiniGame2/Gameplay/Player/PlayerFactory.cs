using Client.Code.MiniGame2.Data;
using Client.Code.MiniGame2.Gameplay.Player.UI;
using Client.Common.Services.AssetLoader;
using Client.Common.Services.Updater;
using UniRx;
using Zenject;

namespace Client.Code.MiniGame2.Gameplay.Player
{
    public class PlayerFactory : IAssetReceiver<MiniGame2Config>
    {
        private readonly IInstantiator _instantiator;
        private readonly MiniGame2SceneData _sceneData;
        private readonly PlayerController _playerController;
        private readonly IUpdater _updater;
        private readonly PlayerTimer _timer;
        private MiniGame2Config _config;

        public PlayerFactory(IInstantiator instantiator, MiniGame2SceneData sceneData, PlayerController playerController, IUpdater updater,
            PlayerTimer timer)
        {
            _instantiator = instantiator;
            _sceneData = sceneData;
            _playerController = playerController;
            _updater = updater;
            _timer = timer;
        }

        public void Create()
        {
            var instance = _instantiator.InstantiatePrefabForComponent<PlayerObject>(_config.PlayerPrefab);
            instance.transform.position = _sceneData.PlayerSpawnPoint.position;
            _playerController.Initialize(instance);
            CreateTimer();

            _updater.OnUpdate += _playerController.OnUpdate;
            _updater.OnFixedUpdate += _playerController.OnFixedUpdate;
            _updater.OnFixedUpdate += _timer.OnUpdate;
        }

        private void CreateTimer()
        {
            var canvas = _instantiator.InstantiatePrefabForComponent<PlayerCanvas>(_config.PlayerCanvasPrefab);
            canvas.PlayerBestScore.Set(_timer.BestScoreMs);
            _timer.CurrentScoreMs.Subscribe(v => canvas.PlayerCurrenScore.Set(v));
            _timer.Start();
        }

        public void Destroy()
        {
            _updater.OnUpdate -= _playerController.OnUpdate;
            _updater.OnFixedUpdate -= _playerController.OnFixedUpdate;
            _updater.OnFixedUpdate -= _timer.OnUpdate;
            _timer.Stop();
        }

        public void Receive(MiniGame2Config asset) => _config = asset;
    }
}