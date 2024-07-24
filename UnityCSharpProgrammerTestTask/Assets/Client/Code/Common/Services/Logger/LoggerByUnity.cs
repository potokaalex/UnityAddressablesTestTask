using Client.Common.Services.Logger.Base;

namespace Client.Common.Services.Logger
{
    public class LoggerByUnity : ILogHandler
    {
        private bool _isInitialize;

        public void Handle(LogData log) => UnityEngine.Debug.Log(log.Message);
    }
}