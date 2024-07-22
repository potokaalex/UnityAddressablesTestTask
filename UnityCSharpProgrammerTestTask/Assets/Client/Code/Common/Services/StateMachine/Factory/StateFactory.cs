using System;
using Zenject;

namespace Client.Common.Services.StateMachine.Factory
{
    public class StateFactory : IStateFactory
    {
        private readonly IInstantiator _container;

        public StateFactory(IInstantiator container) => _container = container;

        public IState Create(Type stateType) => (IState)_container.Instantiate(stateType);
    }
}