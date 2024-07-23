using UnityEngine;

namespace Client.Code.MiniGame2.Gameplay
{
    public class PlayerObject : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent<IInteractiveWith<PlayerObject>>(out var interactive))
                interactive.Interact();
        }
    }
}