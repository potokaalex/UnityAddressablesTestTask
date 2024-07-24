using Client.Code.MiniGame2.Gameplay;
using Client.Code.MiniGame2.Gameplay.Player;
using Client.Common.Services.ProgressService.Saver;
using Client.Common.Services.StateMachine;
using Cysharp.Threading.Tasks;

namespace Client.Code.MiniGame2.Infrastructure.States
{
    public class MiniGame2State : IState
    {
        private readonly PlayerFactory _playerFactory;
        private readonly IProgressSaver _progressSaver;

        public MiniGame2State(PlayerFactory playerFactory, IProgressSaver progressSaver)
        {
            _playerFactory = playerFactory;
            _progressSaver = progressSaver;
        }

        public UniTask Enter()
        {
            _playerFactory.Create();
            return UniTask.CompletedTask;
        }

        public UniTask Exit()
        {
            _playerFactory.Destroy();
            _progressSaver.Save();
            return UniTask.CompletedTask;
        }
    }
}