using Client.Code.MiniGame2.UI;
using Zenject;

namespace Client.Code.MiniGame2.Infrastructure
{
    public class MiniGame2Installer : MonoInstaller
    {
        public override void InstallBindings() => Container.BindInterfacesTo<MiniGame2Presenter>().AsSingle();
    }
}