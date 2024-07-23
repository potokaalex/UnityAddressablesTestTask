namespace Client.Common.UI.Windows.Popup
{
    public interface IPopupWindowFactory
    {
        PopupWindow CreatePopup();
        void DestroyPopup(PopupWindow window);
    }
}