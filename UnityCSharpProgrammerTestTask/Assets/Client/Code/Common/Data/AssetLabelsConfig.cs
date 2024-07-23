using System.Collections.Generic;
using Client.Common.Services.AssetLoader;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Client.Common.Data
{
    [CreateAssetMenu(menuName = "Configs/AssetLabels", fileName = "AssetLabelsConfig", order = 0)]
    public class AssetLabelsConfig : ScriptableObject
    {
        public Dictionary<AssetLabel, AssetLabelReference> Labels;

        public AssetLabelReference Hub;
        public AssetLabelReference MiniGame1;
    }
}