using UnityEngine;

namespace Client.Common.UI.Windows.Base
{
    public abstract class WindowBase : MonoBehaviour, IUIElement, IWindow
    {
        public bool IsOpen { get; private set; }

        public void Open() => OnOpen();

        public void Close() => OnClose();

        private protected virtual void OnOpen()
        {
            IsOpen = true;
            gameObject.SetActive(true);
        }

        private protected virtual void OnClose()
        {
            IsOpen = false;
            gameObject.SetActive(false);
        }
    }
}