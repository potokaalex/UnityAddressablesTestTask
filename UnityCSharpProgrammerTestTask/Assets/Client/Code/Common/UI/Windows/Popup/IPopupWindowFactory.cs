namespace Client.Common.UI.Windows.Popup
{
    public interface IPopupWindowFactory
    {
        PopupWindow CreatePopup();
        PopupsWindow CreatePopups();
        void DestroyPopup(PopupWindow window);
    }
}