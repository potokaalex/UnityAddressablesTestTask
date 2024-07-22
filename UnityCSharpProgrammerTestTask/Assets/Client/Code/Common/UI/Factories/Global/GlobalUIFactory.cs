using Client.Common.Services.AssetLoader;
using Client.Common.UI.Windows;
using Client.Common.UI.Windows.Base;
using UnityEngine;
using Zenject;

namespace Client.Common.UI.Factories.Global
{
    public class GlobalUIFactory : IAssetReceiver, IGlobalUIFactory
    {
        private readonly IInstantiator _instantiator;
        private GlobalCanvas _globalCanvasPrefab;
        private LoadingWindow _loadingWindowPrefab;
        private GlobalCanvas _canvas;
        private LoadingWindow _currentLoadingWindow;
        
        public GlobalUIFactory(IInstantiator instantiator) => _instantiator = instantiator;

        public void Initialize() => _canvas = CreateGlobalCanvas();

        public LoadingWindow CreateLoadingWindow()
        {
            if (!_currentLoadingWindow)
                _currentLoadingWindow = Create(_loadingWindowPrefab, _canvas.DefaultElementsRoot);
            return _currentLoadingWindow;
        }

        public void Destroy<T>(T window) where T : WindowBase => window.Close();

        public void Receive(object asset)
        {
            if (asset is not GameObject gameObject)
                return;

            if (gameObject.TryGetComponent<GlobalCanvas>(out var globalCanvas))
                _globalCanvasPrefab = globalCanvas;

            if (gameObject.TryGetComponent<LoadingWindow>(out var loadingWindow))
                _loadingWindowPrefab = loadingWindow;
        }

        private GlobalCanvas CreateGlobalCanvas() => Create(_globalCanvasPrefab);

        private T Create<T>(T prefab, Transform root = null) where T : MonoBehaviour
        {
            var instance = _instantiator.InstantiatePrefabForComponent<T>(prefab, root);
            return instance;
        }
    }
}