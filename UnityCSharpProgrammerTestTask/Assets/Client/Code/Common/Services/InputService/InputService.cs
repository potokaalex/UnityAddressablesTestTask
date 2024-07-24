using UnityEngine;

namespace Client.Common.Services.InputService
{
    public class InputService : IInputService
    {
        private InputServiceObject _serviceObject;

        public void Initialize(InputServiceObject serviceObject) => _serviceObject = serviceObject;

        public Vector3 MousePosition => Input.mousePosition;

        public bool IsMouseButtonDown(MouseType type)
        {
            if (type == MouseType.Left)
                return Input.GetMouseButtonDown(0);

            return false;
        }

        public bool IsPointerOverGameObject() => _serviceObject.EventSystem.IsPointerOverGameObject();

        public bool IsButton(KeyCode keyCode) => Input.GetKey(keyCode);
    }
}