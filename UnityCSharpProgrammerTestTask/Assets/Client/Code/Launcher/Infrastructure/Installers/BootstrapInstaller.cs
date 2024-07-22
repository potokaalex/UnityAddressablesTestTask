using Client.Common.Services.Startup;
using Client.Launcher.Infrastructure.States;
using Zenject;

namespace Client.Launcher.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings() => Container.BindInterfacesTo<AutoStartupper<ProjectLoadState>>().AsSingle();
    }
}