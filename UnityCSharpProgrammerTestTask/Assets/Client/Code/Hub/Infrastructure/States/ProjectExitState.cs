using Client.Common.Services.ProgressService.Saver;
using Client.Common.Services.StateMachine;
using Client.Common.Services.Updater;
using Cysharp.Threading.Tasks;

namespace Client.Hub.Infrastructure.States
{
    public class ProjectExitState : IState
    {
        private readonly IProgressSaver _progressSaver;
        private readonly IUpdater _updater;

        public ProjectExitState(IProgressSaver progressSaver, IUpdater updater)
        {
            _progressSaver = progressSaver;
            _updater = updater;
        }

        public UniTask Enter()
        {
            _updater.ClearAllListeners();
            _progressSaver.Save();
            return UniTask.CompletedTask;
        }

        public UniTask Exit() => UniTask.CompletedTask;
    }
}