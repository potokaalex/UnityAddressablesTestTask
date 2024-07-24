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
        private readonly IStateMachine _stateMachine;

        public MiniGame1State(CameraFactory cameraFactory, PlayerFactory playerFactory, IStateMachine stateMachine)
        {
            _cameraFactory = cameraFactory;
            _playerFactory = playerFactory;
            _stateMachine = stateMachine;
        }

        public UniTask Enter()
        {
            _cameraFactory.Create();
            _playerFactory.Create();
            return UniTask.CompletedTask;
        }

        public async UniTask Exit()
        {
            _playerFactory.Destroy();
            await _stateMachine.SwitchTo<MiniGame1SaveState>();
        }
    }
}