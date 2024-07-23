using UnityEngine;

namespace Client.Common.Services.InputService
{
    public interface IInputService
    {
        Vector3 MousePosition { get; }
        void Initialize(InputServiceObject serviceObject);
        bool IsMouseButtonDown(MouseType type);
        bool IsPointerOverGameObject();
        bool IsButton(KeyCode keyCode);
    }
}