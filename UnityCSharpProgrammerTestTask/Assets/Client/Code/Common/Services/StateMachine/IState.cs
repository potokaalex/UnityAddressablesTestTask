using Cysharp.Threading.Tasks;

namespace Client.Common.Services.StateMachine
{
    public interface IState
    {
        UniTask Enter();
        UniTask Exit();
    }
}