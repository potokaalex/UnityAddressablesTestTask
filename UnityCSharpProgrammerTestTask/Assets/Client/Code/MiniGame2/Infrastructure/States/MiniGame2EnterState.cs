using Client.Code.MiniGame2.Gameplay;
using Client.Code.MiniGame2.Gameplay.Player;
using Client.Common.Services.StateMachine;
using Cysharp.Threading.Tasks;

namespace Client.Code.MiniGame2.Infrastructure.States
{
    public class MiniGame2EnterState : IState
    {
        private readonly PlayerFactory _playerFactory;

        public MiniGame2EnterState(PlayerFactory playerFactory) => _playerFactory = playerFactory;

        public UniTask Enter()
        {
            _playerFactory.Create();
            return UniTask.CompletedTask;
        }

        public UniTask Exit() => UniTask.CompletedTask;
    }
}