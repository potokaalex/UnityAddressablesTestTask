using Client.Common.UI.Button.Base;

namespace Client.Common.UI.Button.Load
{
    public class LoadButton : ButtonBase
    {
        public LoadButtonType Type;

        public override ButtonType GetBaseType() => ButtonType.Load;
    }
}