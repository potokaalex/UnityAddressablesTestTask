﻿using Client.MiniGame1.Gameplay.GameplayCamera;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Client.MiniGame1.Data
{
    [CreateAssetMenu(menuName = "Configs/MiniGame1", fileName = "MiniGame1Config", order = 0)]
    public class MiniGame1Config : SerializedScriptableObject
    {
        public CameraObject CameraPrefab;
    }
}