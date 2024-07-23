using Client.Common.UI.Windows.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Common.UI.Windows.Loading
{
    public class LoadingWindow : WindowBase
    {
        [SerializeField] private Slider _slider;

        private protected override void OnOpen()
        {
            _slider.value = 0;
            base.OnOpen();
        }

        public void SetProgress(float value, float startValue, float endValue) => _slider.value = Mathf.Lerp(startValue, endValue, value);
    }
}