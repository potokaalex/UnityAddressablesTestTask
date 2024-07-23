using Client.Code.MiniGame2.Infrastructure.States;
using Client.Common.Services.StateMachine;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Client.Code.MiniGame2.Gameplay
{
    public class DefeatObject : MonoBehaviour, IInteractiveWith<PlayerObject>
    {
        private IStateMachine _stateMachine;

        [Inject]
        public void Construct(IStateMachine stateMachine) => _stateMachine = stateMachine;
        
        public void Interact() => _stateMachine.SwitchTo<MiniGame2DefeatState>().Forget();
    }
}