using Client.Common.Services.StateMachine.Factory;

namespace Client.Common.Services.StateMachine.Global
{
    public class GlobalStateMachine : StateMachine, IGlobalStateMachine
    {
        public GlobalStateMachine(IStateFactory factory) : base(factory)
        {
        }
    }
}