using System;
using Client.Common.Services.StateMachine;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Client.Common.Services.Startup
{
    public class Startupper : MonoBehaviour, IStartuper
    {
        private IStateMachine _stateMachine;
        private Type _stateType;

        [Inject]
        public void Construct(IStateMachine stateMachine, Type stateType)
        {
            _stateMachine = stateMachine;
            _stateType = stateType;
        }

        public void Startup() => _stateMachine.SwitchTo(_stateType).Forget();
    }
}