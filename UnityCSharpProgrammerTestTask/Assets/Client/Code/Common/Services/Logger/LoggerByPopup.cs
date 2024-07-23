using Client.Common.Services.Logger.Base;
using Client.Common.UI.Windows.Popup;

namespace Client.Common.Services.Logger
{
    public class LoggerByPopup : ILogHandler
    {
        private readonly IPopupWindowFactory _uiFactory;
        private PopupsWindow _popups;

        public LoggerByPopup(IPopupWindowFactory uiFactory) => _uiFactory = uiFactory;

        public void Handle(LogData log)
        {
            _popups ??= _uiFactory.CreatePopups();
            _popups.Add(log.Message);
        }
    }
}