using Client.Common.UI;
using UnityEngine;

namespace Client.Common.Services.UIFactoryService
{
    public interface IUIFactory
    {
        T Create<T>(T prefab) where T : MonoBehaviour, IUIElement;
    }
}