using Client.Common.UI.Button;
using Client.Common.UI.Button.Base;

namespace Client.Hub.UI.Buttons
{
    public class LoadButton : ButtonBase
    {
        public LoadButtonType Type;

        public override ButtonType GetBaseType() => ButtonType.Load;
    }
}