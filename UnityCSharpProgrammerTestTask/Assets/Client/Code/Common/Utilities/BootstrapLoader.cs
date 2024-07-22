using UnityEngine;
using UnityEngine.SceneManagement;

namespace Client.Common.Utilities
{
    public class BootstrapLoader : MonoBehaviour
    {
#if UNITY_EDITOR
        [SerializeField] private string _bootstrapSceneName;

        private void Awake()
        {
            if (SceneManager.GetActiveScene().name != _bootstrapSceneName)
                SceneManager.LoadScene(_bootstrapSceneName);
        }
#endif
    }
}