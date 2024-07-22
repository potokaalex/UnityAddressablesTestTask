using Client.Common.UI.Base;

namespace Client.Hub.UI.Buttons
{
    public class LoadButton : ButtonBase
    {
        public LoadButtonType Type;

        public override ButtonType GetBaseType() => ButtonType.Load;
    }
}