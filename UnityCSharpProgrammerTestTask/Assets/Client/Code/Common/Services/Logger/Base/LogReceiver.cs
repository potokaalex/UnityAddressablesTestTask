using System.Collections.Generic;

namespace Client.Common.Services.Logger.Base
{
    public class LogReceiver : ILogReceiver
    {
        private readonly List<ILogHandler> _handlers = new();

        public void Log(LogData log)
        {
            foreach (var handler in _handlers)
                handler.Handle(log);
        }

        public void RegisterHandler(ILogHandler handler) => _handlers.Add(handler);

        public void UnRegisterHandler(ILogHandler handler) => _handlers.Remove(handler);
    }
}