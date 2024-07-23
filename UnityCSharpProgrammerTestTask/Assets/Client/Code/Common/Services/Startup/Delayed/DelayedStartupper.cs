using Client.Common.Services.StateMachine;
using Zenject;

namespace Client.Common.Services.Startup.Delayed
{
    public class DelayedStartupper<T> : IInitializable where T : IState
    {
        private readonly IInstantiator _instantiator;

        public DelayedStartupper(IInstantiator instantiator) => _instantiator = instantiator;

        public void Initialize() => _instantiator.InstantiateComponentOnNewGameObject<DelayedStartupperMono>(new[] { typeof(T) });
    }
}