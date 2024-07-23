using Client.Common.Services.AssetLoader;
using Client.Common.Services.Startup;
using Client.Common.Services.Startup.Delayed;
using Client.Common.Services.StateMachine;
using Client.Common.Services.StateMachine.Factory;
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
            BindUI();
            Container.BindInterfacesTo<AssetReceiverRegister>().AsSingle();
            Container.BindInterfacesTo<DelayedStartupper<HubState>>().AsSingle();
        }

        private void BindUI()
        {
            Container.BindInterfacesTo<HubPresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<HubUIFactory>().AsSingle();
        }

        private void BindStateMachine()
        {
            Container.BindInterfacesTo<StateFactory>().AsSingle();
            Container.BindInterfacesTo<StateMachine>().AsSingle();
        }
    }
}