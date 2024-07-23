using System.Collections.Generic;
using Client.Common.Services.InputService;
using Client.Common.UI;
using Client.Common.UI.Windows.Base;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Client.Common.Data.Configs
{
    [CreateAssetMenu(menuName = "Configs/Project", fileName = "ProjectConfig", order = 0)]
    public class ProjectConfig : SerializedScriptableObject
    {
        public ScenesConfig Scenes;
        public AssetLabelsConfig Labels;
        public Dictionary<WindowType, WindowBase> WindowsPrefabs;
        public GlobalCanvas GlobalCanvasPrefab;
        public InputServiceObject InputServiceObjectPrefab;
    }
}