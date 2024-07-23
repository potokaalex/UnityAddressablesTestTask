using Client.Code.MiniGame2.Gameplay;
using UnityEngine;

namespace Client.Code.MiniGame2.Data
{
    [CreateAssetMenu(menuName = "Configs/MiniGame2", fileName = "MiniGame2Config", order = 0)]
    public class MiniGame2Config : ScriptableObject
    {
        public PlayerObject PlayerPrefab;
    }
}