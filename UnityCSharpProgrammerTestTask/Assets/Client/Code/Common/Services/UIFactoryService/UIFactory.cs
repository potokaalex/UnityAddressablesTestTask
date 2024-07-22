using Client.Common.UI;
using UnityEngine;
using Zenject;

namespace Client.Common.Services.UIFactoryService
{
    public class UIFactory : IUIFactory
    {
        private readonly IInstantiator _instantiator;

        public UIFactory(IInstantiator instantiator) => _instantiator = instantiator;

        public T Create<T>(T prefab) where T : MonoBehaviour, IUIElement
        {
            var instance = _instantiator.InstantiatePrefabForComponent<T>(prefab);
            return instance;
        }
    }
}