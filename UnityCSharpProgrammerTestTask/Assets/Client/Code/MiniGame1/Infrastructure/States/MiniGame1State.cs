using Client.Common.Services.StateMachine;
using Client.MiniGame1.Gameplay.GameplayCamera;
using Cysharp.Threading.Tasks;

namespace Client.MiniGame1.Infrastructure.States
{
    public class MiniGame1State : IState
    {
        private readonly CameraFactory _cameraFactory;

        public MiniGame1State(CameraFactory cameraFactory) => _cameraFactory = cameraFactory;

        public UniTask Enter()
        {
            _cameraFactory.Create();
            return UniTask.CompletedTask;
        }

        public UniTask Exit() => UniTask.CompletedTask;
    }
}