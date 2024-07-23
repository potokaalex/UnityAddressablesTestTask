using Client.Hub.UI;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Client.Hub.Infrastructure.Data
{
    [CreateAssetMenu(menuName = "Configs/Hub", fileName = "HubConfig", order = 0)]
    public class HubConfig : SerializedScriptableObject
    {
        public HubCanvasObject CanvasPrefab;
    }
}