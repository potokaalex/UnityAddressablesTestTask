using System;
using Cysharp.Threading.Tasks;

namespace Client.Common.Services.StateMachine
{
    public interface IStateMachine
    {
        UniTask SwitchTo<T>() where T : IState;
        UniTask SwitchTo(Type stateType);
    }
}