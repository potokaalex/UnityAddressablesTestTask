using Client.Code.MiniGame2.Data;
using Client.Code.MiniGame2.Gameplay.Player;
using Client.Code.MiniGame2.Infrastructure.States;
using Client.Code.MiniGame2.UI;
using Client.Common.Services.AssetLoader;
using Client.Common.Services.Startup.Delayed;
using Client.Common.Services.StateMachine;
using Client.Common.Services.StateMachine.Factory;
using UnityEngine;
using Zenject;

namespace Client.Code.MiniGame2.Infrastructure
{
    public class MiniGame2Installer : MonoInstaller
    {
        [SerializeField] private MiniGame2SceneData _sceneData;

        public override void InstallBindings()
        {
            BindStateMachine();
            BindPlayer();
            
            Container.Bind<MiniGame2SceneData>().FromInstance(_sceneData).AsSingle();
            Container.BindInterfacesTo<MiniGame2Presenter>().AsSingle();
            Container.BindInterfacesTo<AssetReceiverRegister>().AsSingle();
            
            Container.BindInterfacesTo<DelayedStartupper<MiniGame2EnterState>>().AsSingle();
        }

        private void BindPlayer()
        {
            Container.BindInterfacesAndSelfTo<PlayerFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerController>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerTimer>().AsSingle();
        }

        private void BindStateMachine()
        {
            Container.BindInterfacesTo<StateFactory>().AsSingle();
            Container.BindInterfacesTo<StateMachine>().AsSingle();
        }
    }
}