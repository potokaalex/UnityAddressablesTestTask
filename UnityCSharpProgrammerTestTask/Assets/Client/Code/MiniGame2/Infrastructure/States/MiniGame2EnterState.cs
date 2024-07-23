using Client.Code.MiniGame2.Gameplay;
using Client.Common.Services.StateMachine;
using Cysharp.Threading.Tasks;

namespace Client.Code.MiniGame2.Infrastructure.States
{
    public class MiniGame2EnterState : IState
    {
        private readonly PlayerFactory _playerFactory;

        public MiniGame2EnterState(PlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }

        public UniTask Enter()
        {
            //создаю персонажа.
            _playerFactory.Create();
            return UniTask.CompletedTask;
        }

        public UniTask Exit()
        {
            return UniTask.CompletedTask;
        }
    }
}