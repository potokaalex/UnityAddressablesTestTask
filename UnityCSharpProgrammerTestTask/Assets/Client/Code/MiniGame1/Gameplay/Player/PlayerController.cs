using Client.Common.Services.InputService;
using Client.MiniGame1.Gameplay.GameplayCamera;
using UnityEngine;

namespace Client.MiniGame1.Gameplay.Player
{
    public class PlayerController
    {
        private readonly IInputService _inputService;
        private readonly CameraController _cameraController;
        private readonly PlayerModel _playerModel;

        public PlayerController(IInputService inputService, PlayerModel playerModel, CameraController cameraController)
        {
            _inputService = inputService;
            _playerModel = playerModel;
            _cameraController = cameraController;
        }

        public void OnUpdate()
        {
            if (_inputService.IsPointerOverGameObject())
                return;

            if (!_inputService.IsMouseButtonDown(MouseType.Left))
                return;

            var ray = _cameraController.GetRayFromCurrentMousePosition();
            var hit = Physics2D.Raycast(ray.origin, ray.direction);
            
            if (hit.transform && hit.transform.TryGetComponent<ClickableSpriteObject>(out _))
                _playerModel.Score.Value++;
        }
    }

    public class PlayerFactory
    {
        public void Create()
        {
            
        }
    }
}