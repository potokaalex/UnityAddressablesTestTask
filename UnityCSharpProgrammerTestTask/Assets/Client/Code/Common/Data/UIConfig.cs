using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Client.Common.Data
{
    [CreateAssetMenu(menuName = "Configs/UI", fileName = "UIConfig", order = 0)]
    public class UIConfig : ScriptableObject
    {
        public AssetReference HubCanvasPrefab;
    }
}