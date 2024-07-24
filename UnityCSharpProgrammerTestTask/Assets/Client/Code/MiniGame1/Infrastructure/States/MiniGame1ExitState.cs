using Client.Common.Infrastructure;
using Client.Common.Services.ProgressService.Saver;
using Client.Common.Services.StateMachine;
using Cysharp.Threading.Tasks;

namespace Client.MiniGame1.Infrastructure.States
{
    public class MiniGame1ExitState : IState
    {
        private readonly IProgressSaver _progressSaver;
        private readonly IStateMachine _stateMachine;

        public MiniGame1ExitState(IProgressSaver progressSaver, IStateMachine stateMachine)
        {
            _progressSaver = progressSaver;
            _stateMachine = stateMachine;
        }

        public async UniTask Enter()
        {
            _progressSaver.Save();
            await _stateMachine.SwitchTo<HubLoadState>();
        }

        public UniTask Exit() => UniTask.CompletedTask;
    }
}