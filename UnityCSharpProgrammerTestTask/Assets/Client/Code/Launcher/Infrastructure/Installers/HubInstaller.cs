using Client.Common.Services.Startup;
using Client.Launcher.Infrastructure.States;
using Client.Launcher.UI;
using Zenject;

namespace Client.Launcher.Infrastructure.Installers
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