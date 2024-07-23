using Client.Common.Services.AssetLoader;
using Client.Common.Services.ProgressService;
using Client.Common.Services.Startup.Delayed;
using Client.Common.Services.StateMachine;
using Client.Common.Services.StateMachine.Factory;
using Client.MiniGame1.Gameplay.GameplayCamera;
using Client.MiniGame1.Gameplay.Player;
using Client.MiniGame1.Gameplay.Player.UI;
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
            Container.BindInterfacesTo<ProgressActorsRegister>().AsSingle();

            Container.BindInterfacesTo<DelayedStartupper<MiniGame1State>>().AsSingle();
        }

        private void BindPlayer()
        {
            Container.Bind<PlayerController>().AsSingle();
            Container.Bind<PlayerPresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerFactory>().AsSingle();
        }

        private void BindCamera()
        {
            Container.Bind<CameraController>().AsSingle();
            Container.BindInterfacesAndSelfTo<CameraFactory>().AsSingle();
        }
        
        private void BindStateMachine()
        {
            Container.BindInterfacesTo<StateFactory>().AsSingle();
            Container.BindInterfacesTo<StateMachine>().AsSingle();
        }
    }
}