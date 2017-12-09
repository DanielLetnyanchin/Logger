using System;

namespace Logger
{

    [Serializable]
    public class LogMessage
    {
        public string LogLevel;
        public string Message;
        public string Source;
        public string StackTrace;
        public DateTime DateTime;

        public LogMessage(string logLevel, string message, string source, string stackTrace)
        {
            LogLevel = logLevel;
            Message = message;
            Source = source;
            StackTrace = stackTrace;
            DateTime = DateTime.Now;
        }

        public LogMessage(string logLevel, string message, string source)
        {
            LogLevel = logLevel;
            Message = message;
            Source = source;
            DateTime = DateTime.Now;
        }

        public LogMessage() { }
    }
}
