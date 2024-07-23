using Client.Common.Data;
using Client.Common.Services.ConfigProvider;
using Client.Common.UI.Windows.Base;
using Client.Common.UI.Windows.Loading;
using Client.Common.UI.Windows.Popup;
using UnityEngine;
using Zenject;

namespace Client.Common.UI.Factories.Global
{
    public class GlobalUIFactory : WindowFactoryBase, IGlobalUIFactory, ILoadingWindowFactory, IPopupWindowFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IConfigProvider _configProvider;
        private ProjectConfig _config;
        private GlobalCanvas _canvas;

        public GlobalUIFactory(IInstantiator instantiator, IConfigProvider configProvider)
        {
            _instantiator = instantiator;
            _configProvider = configProvider;
        }

        public void Initialize()
        {
            _config = _configProvider.Project;
            _canvas = CreateGlobalCanvas();
        }

        public LoadingWindow Create()
        {
            var window = CreateWindow(_config.WindowsPrefabs[WindowType.LoadingWindow], _canvas.DefaultElementsRoot);
            window.Open();
            return (LoadingWindow)window;
        }

        public void Destroy(LoadingWindow window)
        {
            window.Close();
            DestroyWindow(window);
        }

        public PopupWindow CreatePopup() => (PopupWindow)CreateWindow(_config.WindowsPrefabs[WindowType.Popup], _canvas.DefaultElementsRoot);

        public PopupsWindow CreatePopups() => (PopupsWindow)CreateWindow(_config.WindowsPrefabs[WindowType.Popups], _canvas.DefaultElementsRoot);

        public void DestroyPopup(PopupWindow window) => DestroyWindow(window);

        private GlobalCanvas CreateGlobalCanvas() => Create(_config.GlobalCanvasPrefab, null);

        private T Create<T>(T prefab, Transform root) where T : MonoBehaviour => _instantiator.InstantiatePrefabForComponent<T>(prefab, root);

        private protected override WindowBase CreateNewWindow(WindowBase prefab, Transform root) => Create(prefab, root);
    }
}