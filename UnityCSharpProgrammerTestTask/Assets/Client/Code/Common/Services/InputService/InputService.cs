using UnityEngine;

namespace Client.Common.Services.InputService
{
    public class InputService : IInputService
    {
        private InputServiceObject _serviceObject;
        private bool _leftMouseButtonDown;

        public void Initialize(InputServiceObject serviceObject) => _serviceObject = serviceObject;
        
        public bool IsMouseButtonDown(MouseType type)
        {
            if (type == MouseType.Left)
                return _leftMouseButtonDown;

            return false;
        }

        public bool IsPointerOverGameObject() => _serviceObject.EventSystem.IsPointerOverGameObject();

        private void Update() => _leftMouseButtonDown = Input.GetMouseButton(0);
    }
}