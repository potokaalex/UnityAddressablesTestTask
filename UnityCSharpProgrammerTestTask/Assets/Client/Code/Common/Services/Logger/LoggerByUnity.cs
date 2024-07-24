using Client.Common.Services.Logger.Base;

namespace Client.Common.Services.Logger
{
    public class LoggerByUnity : ILogHandler
    {
        public void Handle(LogData log)
        {
#if UNITY_EDITOR
            UnityEngine.Debug.Log($"<color=yellow>Log:</color> {log.Message}");
#endif
        }
    }
}