using Client.Code.MiniGame2.Data;
using Client.Code.MiniGame2.Infrastructure.States;
using Client.Common.Services.AssetLoader;
using Client.Common.Services.InputService;
using Client.Common.Services.StateMachine;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Client.Code.MiniGame2.Gameplay.Player
{
    public class PlayerController : IAssetReceiver<MiniGame2Config>
    {
        private readonly IInputService _inputService;
        private readonly IStateMachine _stateMachine;
        private MiniGame2Config _config;
        private PlayerObject _playerObject;
        private Vector3 _moveDirection;

        public PlayerController(IInputService inputService, IStateMachine stateMachine)
        {
            _inputService = inputService;
            _stateMachine = stateMachine;
        }

        public bool IsWin { get; private set; }

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

        public void Win()
        {
            IsWin = true;
            _stateMachine.SwitchTo<MiniGame2WinState>().Forget();
        }

        public void Defeat() => _stateMachine.SwitchTo<MiniGame2DefeatState>().Forget();

        public void Receive(MiniGame2Config asset) => _config = asset;
    }
}