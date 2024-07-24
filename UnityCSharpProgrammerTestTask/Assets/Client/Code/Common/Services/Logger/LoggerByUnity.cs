using Client.Common.Services.Logger.Base;
using UnityEngine;
using ILogHandler = Client.Common.Services.Logger.Base.ILogHandler;

namespace Client.Common.Services.Logger
{
    public class LoggerByUnity : ILogHandler
    {
        public void Handle(LogData log)
        {
#if UNITY_EDITOR
            Debug.Log($"<color=yellow>Log:</color> {log.Message}");
#endif
        }
    }
}