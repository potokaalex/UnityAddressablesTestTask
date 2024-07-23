using Client.Common.Services.StateMachine;
using Cysharp.Threading.Tasks;

namespace Client.Code.MiniGame2.Infrastructure.States
{
    public class MiniGame2WinState : IState
    {
        public UniTask Enter()
        {
            UnityEngine.Debug.Log("win");
            return UniTask.CompletedTask;
        }

        public UniTask Exit()
        {
            return UniTask.CompletedTask;
        }
    }
}