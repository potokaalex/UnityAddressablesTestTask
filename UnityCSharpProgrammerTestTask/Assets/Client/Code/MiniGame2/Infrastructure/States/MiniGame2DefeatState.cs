using Client.Code.MiniGame2.UI;
using Client.Common.Services.StateMachine;
using Cysharp.Threading.Tasks;

namespace Client.Code.MiniGame2.Infrastructure.States
{
    public class MiniGame2DefeatState : IState
    {
        private readonly MiniGame2UIFactory _uiFactory;

        public MiniGame2DefeatState(MiniGame2UIFactory uiFactory) => _uiFactory = uiFactory;

        public UniTask Enter()
        {
            _uiFactory.CreateDefeatWindow();
            return UniTask.CompletedTask;
        }

        public UniTask Exit() => UniTask.CompletedTask;
    }
}