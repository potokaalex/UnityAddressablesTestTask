using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Client.Common.Data
{
    [CreateAssetMenu(menuName = "Configs/Scenes", fileName = "ScenesConfig", order = 0)]
    public class ScenesConfig : ScriptableObject
    {
        public AssetReference HubKey;
        public AssetReference MiniGame1Key;
        public AssetReference MiniGame2Key;
    }
}