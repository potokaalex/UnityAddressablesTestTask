using UnityEngine;

namespace Client.Common.Services.InputService
{
    public interface IInputService
    {
        Vector3 MousePosition { get; }
        bool IsMouseButtonDown(MouseType type);
        bool IsPointerOverGameObject();
        void Initialize(InputServiceObject serviceObject);
    }
}