namespace Logger
{
    interface ILoggable
    {
        void Log(LogLevel type, string message, string source, string stackTrace);
        void Log(LogLevel level, LogMessage currentMessage);
        void Debug(string message, string source, string stackTrace);
        void Debug(LogMessage currentMessage);
        void Info(string message, string source);
        void Info(LogMessage currentMessage);
        void Warn(string message, string source, string stackTrace);
        void Warn(LogMessage currentMessage);
        void Error(string message, string source, string stackTrace);
        void Error(LogMessage currentMessage);
    }
}
