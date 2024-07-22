using Client.Common.Services.Startup.Auto;
using Client.Common.Services.StateMachine;
using Client.Common.Services.StateMachine.Factory;
using Client.Common.Services.UIFactoryService;
using Client.Hub.Infrastructure.States;
using Client.Hub.UI;
using Zenject;

namespace Client.Hub.Infrastructure.Installers
{
    public class HubInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindStateMachine();
            Container.BindInterfacesTo<HubPresenter>().AsSingle();
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
            Container.BindInterfacesTo<AutoStartupper<HubEnterState>>().AsSingle();
        }
        
        private void BindStateMachine()
        {
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
            Container.Bind<IStateMachine>().To<StateMachine>().AsSingle();
        }
    }
}