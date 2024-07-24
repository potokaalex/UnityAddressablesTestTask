using Client.Common.Services.AssetLoader;
using Client.Common.Services.InputService;
using Client.Common.Services.InputService.Factory;
using Client.Common.Services.Logger;
using Client.Common.Services.Logger.Base;
using Client.Common.Services.ProgressService.Loader;
using Client.Common.Services.ProgressService.Saver;
using Client.Common.Services.SceneLoader;
using Client.Common.Services.Startup.Runner;
using Client.Common.Services.StateMachine.Factory;
using Client.Common.Services.StateMachine.Global;
using Client.Common.Services.Updater;
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
            BindLog();
            BindInputService();
            BindProgress();

            Container.BindInterfacesTo<SceneLoader>().AsSingle();
            Container.BindInterfacesTo<GlobalUIFactory>().AsSingle();
            Container.BindInterfacesTo<Updater>().FromNewComponentOnNewGameObject().AsSingle();
            Container.BindInterfacesTo<StartupRunner>().AsSingle();
        }

        private void BindProgress()
        {
            Container.BindInterfacesTo<ProgressLoader>().AsSingle();
            Container.BindInterfacesTo<ProgressSaver>().AsSingle();
        }

        private void BindInputService()
        {
            Container.BindInterfacesTo<InputServiceFactory>().AsSingle();
            Container.BindInterfacesTo<InputService>().AsSingle();
        }

        private void BindLog()
        {
            Container.BindInterfacesTo<LogReceiver>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoggerByPopup>().AsSingle();
            Container.BindInterfacesTo<LoggerByUnity>().AsSingle();
            Container.BindInterfacesTo<AddressablesCustomExceptionHandler>().AsSingle();
            Container.BindInterfacesTo<LogHandlersRegister>().AsSingle();
        }

        private void BindAssetLoader()
        {
            Container.BindInterfacesTo<AssetLoader>().AsSingle().WithArguments(_projectLabel);
            Container.BindInterfacesTo<AssetReceiverRegister>().AsSingle();
        }

        private void BindStateMachine()
        {
            Container.BindInterfacesTo<StateFactory>().AsSingle();
            Container.BindInterfacesTo<GlobalStateMachine>().AsSingle();
        }
    }
}