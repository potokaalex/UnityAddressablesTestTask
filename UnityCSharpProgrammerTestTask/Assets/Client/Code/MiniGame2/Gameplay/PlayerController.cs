using Client.Code.MiniGame2.Data;
using Client.Common.Services.AssetLoader;
using Client.Common.Services.InputService;
using UnityEngine;

namespace Client.Code.MiniGame2.Gameplay
{
    public class PlayerController : IAssetReceiver<MiniGame2Config>
    {
        private readonly IInputService _inputService;
        private MiniGame2Config _config;
        private PlayerObject _playerObject;
        private Vector3 _moveDirection;

        public PlayerController(IInputService inputService) => _inputService = inputService;

        public void Initialize(PlayerObject playerObject) => _playerObject = playerObject;
        
        public void OnUpdate()
        {
            _moveDirection = Vector3.zero;

            if (_inputService.IsButton(KeyCode.W))
                _moveDirection += Vector3.forward;
            if (_inputService.IsButton(KeyCode.S))
                _moveDirection += Vector3.back;
            if (_inputService.IsButton(KeyCode.D))
                _moveDirection += Vector3.right;
            if (_inputService.IsButton(KeyCode.A))
                _moveDirection += Vector3.left;
        }

        public void OnFixedUpdate() => _playerObject.transform.position += _moveDirection * Time.fixedDeltaTime * _config.PlayerMoveSpeed;
        
        public void Receive(MiniGame2Config asset) => _config = asset;
    }
}