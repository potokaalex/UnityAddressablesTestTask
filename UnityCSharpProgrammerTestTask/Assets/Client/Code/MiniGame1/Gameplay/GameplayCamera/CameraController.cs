using Client.Common.Services.InputService;
using UnityEngine;

namespace Client.MiniGame1.Gameplay.GameplayCamera
{
    public class CameraController
    {
        private CameraObject _cameraObject;
        private readonly IInputService _inputService;

        public CameraController(IInputService inputService) => _inputService = inputService;

        public void Initialize(CameraObject cameraObject) => _cameraObject = cameraObject;
        
        public Ray GetRayFromCurrentMousePosition() => _cameraObject.Camera.ScreenPointToRay(_inputService.MousePosition);
    }
}