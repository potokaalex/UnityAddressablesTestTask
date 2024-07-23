using UnityEngine;

namespace Client.Code.MiniGame2.Gameplay
{
    public interface IInteractiveWith<T> where T : MonoBehaviour
    {
        public void Interact();
    }
}