using Client.Common.UI.Button.Base;

namespace Client.Hub.UI.Buttons.Unload
{
    public class UnloadButton : ButtonBase
    {
        public UnloadButtonType Type;

        public override ButtonType GetBaseType() => ButtonType.Unload;
    }
}