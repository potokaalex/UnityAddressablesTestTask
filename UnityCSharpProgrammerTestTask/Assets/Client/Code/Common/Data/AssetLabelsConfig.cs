using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Client.Common.Data
{
    [CreateAssetMenu(menuName = "Configs/AssetLabels", fileName = "AssetLabelsConfig", order = 0)]
    public class AssetLabelsConfig : ScriptableObject
    {
        public AssetLabelReference Hub;
    }
}