namespace Client.Common.Services.StateMachine
{
    public interface IState
    {
        void Enter();

        void Exit()
        {
        }
    }
}