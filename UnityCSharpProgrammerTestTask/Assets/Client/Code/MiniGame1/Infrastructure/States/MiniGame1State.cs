using Client.Common.Services.StateMachine;
using Client.MiniGame1.Gameplay.GameplayCamera;
using Client.MiniGame1.Gameplay.Player;
using Cysharp.Threading.Tasks;

namespace Client.MiniGame1.Infrastructure.States
{
    public class MiniGame1State : IState
    {
        private readonly CameraFactory _cameraFactory;
        private readonly PlayerFactory _playerFactory;

        public MiniGame1State(CameraFactory cameraFactory, PlayerFactory playerFactory)
        {
            _cameraFactory = cameraFactory;
            _playerFactory = playerFactory;
        }

        public UniTask Enter()
        {
            _cameraFactory.Create();
            _playerFactory.Create();
            return UniTask.CompletedTask;
        }

        public UniTask Exit()
        {
            _playerFactory.Destroy();
            return UniTask.CompletedTask;
        }
    }
}