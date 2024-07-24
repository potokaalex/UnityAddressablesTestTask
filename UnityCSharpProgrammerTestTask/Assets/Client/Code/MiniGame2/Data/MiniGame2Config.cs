using Client.Code.MiniGame2.Gameplay.Player;
using Client.Code.MiniGame2.Gameplay.Player.UI;
using Client.Code.MiniGame2.UI;
using UnityEngine;

namespace Client.Code.MiniGame2.Data
{
    [CreateAssetMenu(menuName = "Configs/MiniGame2", fileName = "MiniGame2Config", order = 0)]
    public class MiniGame2Config : ScriptableObject
    {
        public PlayerCanvas PlayerCanvasPrefab;
        public PlayerObject PlayerPrefab;
        public float PlayerMoveSpeed;

        public MiniGame2WinWindow WinWindowPrefab;
        public MiniGame2DefeatWindow DefeatWindowPrefab;
    }
}