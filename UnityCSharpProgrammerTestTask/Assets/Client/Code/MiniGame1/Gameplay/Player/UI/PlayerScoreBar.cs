using System.Globalization;
using TMPro;
using UnityEngine;

namespace Client.MiniGame1.Gameplay.Player.UI
{
    public class PlayerScoreBar : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;     
        
        public void Set(float value) => _text.SetText(value.ToString(CultureInfo.InvariantCulture));
    }
}