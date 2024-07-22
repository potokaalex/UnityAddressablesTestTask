using Client.Common.Utilities.Editor.Base;
using UnityEditor;

namespace Client.Common.Utilities.Editor
{
    public static class StateMachineDebugToggle
    {
        private const string MenuItemPath = "Tools/Debug/DEBUG_STATE_MACHINE";
        private const string Symbol = "DEBUG_STATE_MACHINE";

        [MenuItem(MenuItemPath)]
        private static void ToggleDebugSymbol() => DefineSymbolsToggleTool.ToggleDebugSymbol(Symbol);

        [MenuItem(MenuItemPath, true)]
        private static bool ToggleDebugSymbolValidate() => DefineSymbolsToggleTool.ToggleDebugSymbolValidate(Symbol, MenuItemPath);
    }
}