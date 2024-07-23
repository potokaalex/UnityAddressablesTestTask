using Client.Common.Services.StateMachine;
using Cysharp.Threading.Tasks;

namespace Client.Code.MiniGame2.Infrastructure.States
{
    public class MiniGame2DefeatState : IState
    {
        public UniTask Enter()
        {
            UnityEngine.Debug.Log("defeat");
            return UniTask.CompletedTask;
        }

        public UniTask Exit()
        {
            return UniTask.CompletedTask;
        }
    }
}