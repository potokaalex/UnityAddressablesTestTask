using System.Collections.Generic;
using Client.Common.Services.AssetLoader;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Client.Common.Data.Configs
{
    [CreateAssetMenu(menuName = "Configs/AssetLabels", fileName = "AssetLabelsConfig", order = 0)]
    public class AssetLabelsConfig : SerializedScriptableObject
    {
        public Dictionary<AssetLabel, AssetLabelReference> Keys;
    }
}