using Client.Common.UI.Base;

namespace Client.Launcher.UI.Buttons
{
    public class LoadMiniGameButton : ButtonBase
    {
        public LoadMiniGameButtonType Type;

        public override ButtonType GetBaseType() => ButtonType.LoadMiniGame;
    }
}