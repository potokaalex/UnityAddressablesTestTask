using Client.Common.Services.AssetLoader;
using Client.Common.Services.Startup;
using Client.Common.Services.StateMachine;
using Client.Common.Services.StateMachine.Factory;
using Client.MiniGame1.Gameplay.GameplayCamera;
using Client.MiniGame1.Gameplay.Player;
using Client.MiniGame1.Infrastructure.States;
using Client.MiniGame1.UI;
using Zenject;

namespace Client.MiniGame1.Infrastructure
{
    public class MiniGame1Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindCamera();
            BindPlayer();
            BindStateMachine();
            
            Container.BindInterfacesTo<MiniGame1Presenter>().AsSingle();
            Container.BindInterfacesTo<AssetReceiverRegister>().AsSingle();

            Container.BindInterfacesTo<DelayStartupper<MiniGame1State>>().AsSingle();
        }

        private void BindPlayer()
        {
            Container.Bind<PlayerController>().AsSingle();
            Container.Bind<PlayerModel>().AsSingle();
        }

        private void BindCamera()
        {
            Container.Bind<CameraController>().AsSingle();
            Container.BindInterfacesAndSelfTo<CameraFactory>().AsSingle();
        }
        
        private void BindStateMachine()
        {
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
            Container.Bind<IStateMachine>().To<StateMachine>().AsSingle();
        }
    }
}