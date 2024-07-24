using System;
using System.Collections.Generic;
using Client.Common.UI.Windows.Base;
using UnityEngine;

namespace Client.Common.UI.Factories
{
    public abstract class WindowFactoryBase
    {
        private readonly Dictionary<Type, List<WindowBase>> _windows = new();

        private protected T CreateWindow<T>(T prefab, Transform root) where T : WindowBase
        {
            if (!_windows.TryGetValue(prefab.GetType(), out var windows) || windows.Count == 0)
                return (T)CreateNewWindow(prefab, root);

            var window = windows[^1];
            windows.RemoveAt(windows.Count - 1);

            return (T)window;
        }

        private protected void DestroyWindow(WindowBase window)
        {
            if (!_windows.TryGetValue(window.GetType(), out var windows))
                _windows.Add(window.GetType(), new List<WindowBase> { window });
            else
                windows.Add(window);
        }

        private protected abstract WindowBase CreateNewWindow(WindowBase prefab, Transform root);
    }
}