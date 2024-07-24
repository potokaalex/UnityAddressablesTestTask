using Client.Common.Services.StateMachine;
using Cysharp.Threading.Tasks;

namespace Client.Code.MiniGame2.Infrastructure.States
{
    public class MiniGame2WinState : IState
    {
        public UniTask Enter()
        {
            //как засечь время до события ? Нужен таймер. Нужно создать таймер.
            UnityEngine.Debug.Log("win");
            return UniTask.CompletedTask;
        }

        public UniTask Exit()
        {
            return UniTask.CompletedTask;
        }
    }
}