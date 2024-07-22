using Client.Common.Services.AssetLoader;
using Client.Common.Services.ConfigProvider;
using Client.Common.Services.SceneLoader;
using Client.Common.Services.Startup.Runner;
using Client.Common.Services.StateMachine;
using Client.Common.Services.StateMachine.Factory;
using Client.Common.UI.Factories.Global;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Client.Hub.Infrastructure.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private AssetLabelReference _projectLabel;
        
        public override void InstallBindings()
        {
            BindStateMachine();
            BindAssetLoader();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.BindInterfacesTo<ConfigProvider>().AsSingle();
            Container.Bind<IStartupRunner>().To<StartupRunner>().AsSingle();

            Container.BindInterfacesTo<GlobalUIFactory>().AsSingle();
        }

        private void BindAssetLoader()
        {
            Container.Bind<IAssetLoader>().To<AssetLoader>().AsSingle().WithArguments(_projectLabel);
            Container.BindInterfacesTo<AssetReceiverRegister>().AsSingle();
        }

        private void BindStateMachine()
        {
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
#if DEBUG_STATE_MACHINE
            Container.Bind<IProjectStateMachine>().To<StateMachine>().AsSingle().WithArguments(true);
#else
            Container.Bind<IProjectStateMachine>().To<StateMachine>().AsSingle();
#endif
        }
    }
}