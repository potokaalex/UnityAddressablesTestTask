using Client.Common.Services.StateMachine;
using Client.Common.Services.Updater;
using Client.MiniGame1.Gameplay.GameplayCamera;
using Client.MiniGame1.Gameplay.Player;
using Cysharp.Threading.Tasks;

namespace Client.MiniGame1.Infrastructure.States
{
    public class MiniGame1State : IState
    {
        private readonly CameraFactory _cameraFactory;
        private readonly IUpdater _updater;
        private readonly PlayerController _playerController;

        public MiniGame1State(CameraFactory cameraFactory, IUpdater updater, PlayerController playerController)
        {
            _cameraFactory = cameraFactory;
            _updater = updater;
            _playerController = playerController;
        }

        public UniTask Enter()
        {
            _cameraFactory.Create();
            _updater.OnUpdate += Update;
            return UniTask.CompletedTask;
        }

        private void Update() => _playerController.OnUpdate();

        public UniTask Exit()
        {
            _updater.OnUpdate -= Update;
            return UniTask.CompletedTask;
        }
    }
}