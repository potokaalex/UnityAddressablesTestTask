using Client.MiniGame1.Gameplay;
using Client.MiniGame1.Gameplay.GameplayCamera;
using Client.MiniGame1.Gameplay.Player;
using Client.MiniGame1.UI;
using Zenject;

namespace Client.MiniGame1.Infrastructure
{
    public class MiniGame1Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CameraController>().AsSingle();
            Container.BindInterfacesTo<CameraFactory>().AsSingle();
            
            Container.Bind<PlayerController>().AsSingle();
            Container.Bind<PlayerModel>().AsSingle();
                
            Container.BindInterfacesTo<MiniGame1Presenter>().AsSingle();
        }
    }
}