using Client.Code.MiniGame2.Gameplay.Player;
using Client.Common.Services.StateMachine;
using Cysharp.Threading.Tasks;

namespace Client.Code.MiniGame2.Infrastructure.States
{
    public class MiniGame2State : IState
    {
        private readonly PlayerFactory _playerFactory;

        public MiniGame2State(PlayerFactory playerFactory) => _playerFactory = playerFactory;

        public UniTask Enter()
        {
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