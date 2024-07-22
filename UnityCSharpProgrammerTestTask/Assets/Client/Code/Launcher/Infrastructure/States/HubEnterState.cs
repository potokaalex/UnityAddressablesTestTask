using Client.Common.Services.StateMachine;
using UnityEngine;

namespace Client.Launcher.Infrastructure.States
{
    public class HubEnterState : IState
    {
        public void Enter() => Debug.Log("123");
    }
}