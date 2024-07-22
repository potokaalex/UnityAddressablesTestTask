using System;

namespace Client.Common.Services.StateMachine.Factory
{
    public interface IStateFactory
    {
        IState Create(Type stateType);
    }
}