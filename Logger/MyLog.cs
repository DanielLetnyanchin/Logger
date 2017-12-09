using System;
using System.Configuration;

namespace Logger
{
    public class MyLog : ILoggable , IDisposable
    {
        private IImplementable implementor;
        private string debugFileWay;
        private string infoFileWay;
        private string warnFileWay;
        private string errorFileWay;

        bool disposed = false;

        public MyLog()
        {
            switch (ConfigurationManager.AppSettings.Get("serializeTo").ToLower())
            {
                case "plain":
                    implementor = new SerializerPlain();
                    break;
                case "json":
                    implementor = new SerializerJson();
                    break;
                case "soap":
                    implementor = new SerializerSoap();
                    break;
                case "xml":
                    implementor = new SerializerXml();
                    break;
                default:
                    break;
            }

            debugFileWay = ConfigurationManager.AppSettings.Get("debugFileWay");
            infoFileWay = ConfigurationManager.AppSettings.Get("infoFileWay");
            warnFileWay = ConfigurationManager.AppSettings.Get("warnFileWay");
            errorFileWay = ConfigurationManager.AppSettings.Get("errorFileWay");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
            }
            disposed = true;
        }

        ~MyLog()
        {
            Dispose(false);
        }

        public void Log(LogLevel level, string message, string source, string stackTrace)
        {
            switch (level.ToString())
            {
                case "Debug":
                    Debug(message, source, stackTrace);
                    break;
                case "Info":
                    Info(message, source);
                    break;
                case "Warn":
                    Warn(message, source, stackTrace);
                    break;
                case "Error":
                    Error(message, source, stackTrace);
                    break;
                default:
                    break;
            }
        }

        public void Log(LogLevel level, LogMessage currentMessage)
        {
            switch (level.ToString())
            {
                case "Debug":
                    Debug(currentMessage);
                    break;
                case "Info":
                    Info(currentMessage);
                    break;
                case "Warn":
                    Warn(currentMessage);
                    break;
                case "Error":
                    Error(currentMessage);
                    break;
                default:
                    break;
            }
        }

        public void Debug(string message, string source, string stackTrace)
        {
            var currentMessage = new LogMessage("Debug", message, source, stackTrace);

            implementor.ConvertToFile(debugFileWay, currentMessage);
        }

        public void Debug(LogMessage currentMessage)
        {
            implementor.ConvertToFile(debugFileWay, currentMessage);
        }

        public void Info(string message, string source)
        {
            var currentMessage = new LogMessage("Info", message, source);

            implementor.ConvertToFile(infoFileWay, currentMessage);
        }

        public void Info(LogMessage currentMessage)
        {
            implementor.ConvertToFile(infoFileWay, currentMessage);
        }

        public void Warn(string message, string source, string stackTrace)
        {
            var currentMessage = new LogMessage("Warn", message, source, stackTrace);

            implementor.ConvertToFile(warnFileWay, currentMessage);
        }

        public void Warn(LogMessage currentMessage)
        {
            implementor.ConvertToFile(warnFileWay, currentMessage);
        }

        public void Error(string message, string source, string stackTrace)
        {
            var currentMessage = new LogMessage("Error", message, source, stackTrace);

            implementor.ConvertToFile(errorFileWay, currentMessage);
        }

        public void Error(LogMessage currentMessage)
        {
            implementor.ConvertToFile(errorFileWay, currentMessage);
        }
    }
}
