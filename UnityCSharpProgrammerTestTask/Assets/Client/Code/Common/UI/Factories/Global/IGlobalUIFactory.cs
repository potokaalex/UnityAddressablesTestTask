using Client.Common.UI.Windows;
using Client.Common.UI.Windows.Base;

namespace Client.Common.UI.Factories.Global
{
    public interface IGlobalUIFactory
    {
        void Initialize();
        LoadingWindow CreateLoadingWindow();
        void Destroy<T>(T element) where T : WindowBase;
    }
}