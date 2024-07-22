namespace Client.Common.UI.Windows.Base
{
    public interface IWindow
    {
        bool IsOpen { get; }
        void Open();
        void Close();
    }
}