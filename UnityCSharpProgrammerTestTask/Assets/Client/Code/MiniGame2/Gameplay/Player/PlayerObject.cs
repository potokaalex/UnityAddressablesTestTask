using UnityEngine;
using Zenject;

namespace Client.Code.MiniGame2.Gameplay.Player
{
    public class PlayerObject : MonoBehaviour
    {
        private PlayerController _controller;

        [Inject]
        public void Construct(PlayerController controller) => _controller = controller;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<DefeatObject>(out _))
                _controller.Defeat();
            else if (other.TryGetComponent<FinishObject>(out _))
                _controller.Win();
        }
    }
}