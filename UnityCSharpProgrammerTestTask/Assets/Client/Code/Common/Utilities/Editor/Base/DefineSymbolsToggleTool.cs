using UnityEditor;

namespace Client.Common.Utilities.Editor.Base
{
    public static class DefineSymbolsToggleTool
    {
        public static void ToggleDebugSymbol(string symbol)
        {
            var targetGroup = EditorUserBuildSettings.selectedBuildTargetGroup;
            var scriptingDefineSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(targetGroup);

            if (scriptingDefineSymbols.Contains(symbol))
                scriptingDefineSymbols = scriptingDefineSymbols.Replace(symbol, string.Empty);
            else if (string.IsNullOrEmpty(scriptingDefineSymbols))
                scriptingDefineSymbols = symbol;
            else
                scriptingDefineSymbols += ";" + symbol;

            PlayerSettings.SetScriptingDefineSymbolsForGroup(targetGroup, scriptingDefineSymbols);
        }

        public static bool ToggleDebugSymbolValidate(string symbol, string menuItemPath)
        {
            var targetGroup = EditorUserBuildSettings.selectedBuildTargetGroup;
            var scriptingDefineSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(targetGroup);

            var isSymbolDefined = scriptingDefineSymbols.Contains(symbol);

            Menu.SetChecked(menuItemPath, isSymbolDefined);
            return true;
        }
    }
}