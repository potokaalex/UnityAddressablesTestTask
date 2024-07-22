using Client.Common.Services.Startup;
using Client.Hub.Infrastructure.States;
using Client.Hub.UI;
using Zenject;

namespace Client.Hub.Infrastructure.Installers
{
    public class HubInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<HubPresenter>().AsSingle();
            Container.BindInterfacesTo<AutoStartupper<HubEnterState>>().AsSingle();
        }
    }
}