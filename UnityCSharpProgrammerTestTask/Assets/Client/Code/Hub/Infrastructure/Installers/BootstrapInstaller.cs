using Client.Common.Services.Startup;
using Client.Common.Services.Startup.Auto;
using Client.Hub.Infrastructure.States;
using Zenject;

namespace Client.Hub.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings() => Container.BindInterfacesTo<AutoStartupperGlobal<ProjectLoadState>>().AsSingle();
    }
}