using System.Collections;
using Client.Common.UI.Windows.Base;
using TMPro;
using UnityEngine;
using Zenject;

namespace Client.Common.UI.Windows.Popup
{
    public class PopupWindow : WindowBase
    {
        [SerializeField] private TMP_Text _text;
        private IPopupWindowFactory _windowFactory;

        [Inject]
        public void Construct(IPopupWindowFactory windowFactory) => _windowFactory = windowFactory;

        public void Initialize(string message)
        {
            _text.text = message;
            Open();
            StartCoroutine(Hide());
        }

        private IEnumerator Hide()
        {
            yield return new WaitForSeconds(5);
            Close();
            _windowFactory.DestroyPopup(this);
        }
    }
}