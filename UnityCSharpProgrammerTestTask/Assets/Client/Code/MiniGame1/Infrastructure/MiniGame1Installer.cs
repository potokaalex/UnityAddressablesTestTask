using Client.MiniGame1.UI;
using Zenject;

namespace Client.MiniGame1.Infrastructure
{
    public class MiniGame1Installer : MonoInstaller
    {
        public override void InstallBindings() => Container.BindInterfacesTo<MiniGame1Presenter>().AsSingle();
    }
}