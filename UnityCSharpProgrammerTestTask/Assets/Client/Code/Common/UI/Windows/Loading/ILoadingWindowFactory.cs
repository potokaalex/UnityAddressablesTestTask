namespace Client.Common.UI.Windows.Loading
{
    public interface ILoadingWindowFactory
    {
        LoadingWindow Create();
        void Destroy(LoadingWindow window);
    }
}