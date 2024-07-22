using Client.Common.Services.StateMachine;

namespace Client.Launcher.Infrastructure.States
{
    public class HubEnterState : IState
    {
        public void Enter() => UnityEngine.Debug.Log("123");
    }
}