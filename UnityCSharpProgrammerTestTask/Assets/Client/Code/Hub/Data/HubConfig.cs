using Client.Hub.UI;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Client.Hub.Data
{
    [CreateAssetMenu(menuName = "Configs/Hub", fileName = "HubConfig", order = 0)]
    public class HubConfig : SerializedScriptableObject
    {
        public HubCanvasObject CanvasPrefab;
    }
}