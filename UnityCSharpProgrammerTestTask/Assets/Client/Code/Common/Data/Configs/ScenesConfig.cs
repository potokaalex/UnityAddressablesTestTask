using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Client.Common.Data.Configs
{
    [CreateAssetMenu(menuName = "Configs/Scenes", fileName = "ScenesConfig", order = 0)]
    public class ScenesConfig : SerializedScriptableObject
    {
        //Serialization BUG! Cant use Dictionary<SceneName, AssetReference>
        public AssetReference Hub;
        public AssetReference MiniGame1;
        public AssetReference MiniGame2;
    }
}