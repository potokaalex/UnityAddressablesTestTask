using System;

namespace Client.Common.Services.StateMachine
{
    public interface IStateMachine
    {
        void SwitchTo<T>() where T : IState;
        void SwitchTo(Type stateType);
    }
}