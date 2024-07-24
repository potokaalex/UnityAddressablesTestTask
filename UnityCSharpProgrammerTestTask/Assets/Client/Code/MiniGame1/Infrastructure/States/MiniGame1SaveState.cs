using Client.Common.Services.ProgressService.Saver;
using Client.Common.Services.StateMachine;
using Cysharp.Threading.Tasks;

namespace Client.MiniGame1.Infrastructure.States
{
    public class MiniGame1SaveState : IState
    {
        private readonly IProgressSaver _progressSaver;

        public MiniGame1SaveState(IProgressSaver progressSaver) => _progressSaver = progressSaver;

        public UniTask Enter()
        {
            _progressSaver.Save();
            return UniTask.CompletedTask;
        }

        public UniTask Exit() => UniTask.CompletedTask;
    }
}