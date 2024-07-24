using System.Globalization;
using TMPro;
using UnityEngine;

namespace Client.Code.MiniGame2.Gameplay.Player.UI
{
    public class PlayerTimeBar : MonoBehaviour
    {
        [SerializeField] private TMP_Text _timeText;

        public void Set(float timeMs)
        {
            var sec = timeMs / 1000;
            var ms = timeMs % 1000 / 10;
            var text = $"{(int)sec:D2}:{(int)ms:D2}";
            _timeText.SetText(text.ToString(CultureInfo.InvariantCulture));
        }
    }
}