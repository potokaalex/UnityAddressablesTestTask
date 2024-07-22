using Client.Common.Services.Startup;
using Client.Common.Services.StateMachine;
using Client.Common.Services.StateMachine.Factory;
using Client.Launcher.Infrastructure.States;
using Zenject;

namespace Client.Launcher.Infrastructure.Installers
{
    public class HubInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindStateMachine();
            Container.BindInterfacesTo<DelayStartupper<HubEnterState>>().AsSingle();
        }

        private void BindStateMachine()
        {
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
            Container.Bind<IStateMachine>().To<StateMachine>().AsSingle();
        }
    }
}