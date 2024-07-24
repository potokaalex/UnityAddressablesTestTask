using Client.Common.Infrastructure;
using Client.Common.Services.ProgressService.Saver;
using Client.Common.Services.StateMachine;
using Cysharp.Threading.Tasks;

namespace Client.Code.MiniGame2.Infrastructure.States
{
    public class MiniGame2ExitState : IState
    {
        private readonly IProgressSaver _progressSaver;
        private readonly IStateMachine _stateMachine;

        public MiniGame2ExitState(IProgressSaver progressSaver, IStateMachine stateMachine)
        {
            _progressSaver = progressSaver;
            _stateMachine = stateMachine;
        }

        public UniTask Enter()
        {
            _progressSaver.Save();
            _stateMachine.SwitchTo<HubLoadState>().Forget();
            return UniTask.CompletedTask;
        }

        public UniTask Exit() => UniTask.CompletedTask;
    }
}