using Client.Common.UI.Windows.Base;
using UnityEngine;
using Zenject;

namespace Client.Common.UI.Windows.Popup
{
    public class PopupsWindow : WindowBase
    {
        [SerializeField] private Transform _popupsRoot;
        private IPopupWindowFactory _uiFactory;

        [Inject]
        public void Construct(IPopupWindowFactory uiFactory) => _uiFactory = uiFactory;

        public void Add(string message)
        {
            var popup = _uiFactory.CreatePopup();
            popup.transform.SetParent(_popupsRoot, false);
            popup.Initialize(message);
        }
    }
}