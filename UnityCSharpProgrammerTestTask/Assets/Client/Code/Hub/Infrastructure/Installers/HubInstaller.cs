using Client.Common.Services.AssetLoader;
using Client.Common.Services.Startup;
using Client.Common.Services.StateMachine;
using Client.Common.Services.StateMachine.Factory;
using Client.Hub.Infrastructure.States;
using Client.Hub.Services;
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
            Container.BindInterfacesAndSelfTo<HubUIFactory>().AsSingle();
            Container.BindInterfacesTo<DelayStartupper<HubEnterState>>().AsSingle();
            Container.BindInterfacesTo<AssetReceiverRegister>().AsSingle();
        }
        
        private void BindStateMachine()
        {
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
            Container.Bind<IStateMachine>().To<StateMachine>().AsSingle();
        }
    }
}