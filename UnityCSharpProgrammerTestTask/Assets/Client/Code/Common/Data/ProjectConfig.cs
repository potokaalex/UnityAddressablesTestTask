using UnityEngine;

namespace Client.Common.Data
{
    [CreateAssetMenu(menuName = "Configs/Project", fileName = "ProjectConfig", order = 0)]
    public class ProjectConfig : ScriptableObject
    {
        public ScenesConfig Scenes;
        public UIConfig UI;
        public AssetLabelsConfig Labels;
    }
}