using Client.Common.Services.AssetLoader;
using Client.Common.Services.SceneLoader;
using Client.Common.Services.StateMachine;
using Client.Common.Services.StateMachine.Factory;
using Client.Common.Services.StaticDataProvider;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Client.Launcher.Infrastructure.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private AssetReference _projectConfig;
        
        public override void InstallBindings()
        {
            BindStateMachine();
            Container.Bind<IAssetLoader>().To<AssetLoader>().AsSingle().WithArguments(_projectConfig);
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<IStaticDataProvider>().To<StaticDataProvider>().AsSingle();
        }

        private void BindStateMachine()
        {
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
            Container.Bind<IProjectStateMachine>().To<StateMachine>().AsSingle();
        }
    }
}