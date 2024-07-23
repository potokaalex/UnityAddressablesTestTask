using Client.Common.Services.Logger.Base;
using Client.Common.UI.Windows.Popup;

namespace Client.Common.Services.Logger
{
    public class LoggerByPopup : ILogHandler
    {
        private readonly IPopupWindowFactory _uiFactory;

        public LoggerByPopup(IPopupWindowFactory uiFactory) => _uiFactory = uiFactory;

        public void Handle(LogData log)
        {
            //var popups = _uiFactory.CreatePopups();
            //popups.Add(log.Message);
            UnityEngine.Debug.Log(log.Message);
        }
    }
}