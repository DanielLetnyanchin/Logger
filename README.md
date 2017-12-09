Logger - реалізація логеру що після компіляції являє собою dll яку можна підключити в інший проект       
TestApp - демонстрація роботи логера
Налаштування логера (аналогічно nlog) здійснюются додаванням до файлу конфігурації App.config наступного коду:

  <appSettings>
    <add key="serializeTo" value="plain" />
    <add key="debugFileWay" value="LogFiles\debug.txt" />
    <add key="infoFileWay" value="LogFiles\info.txt" />
    <add key="warnFileWay" value="LogFiles\warn.txt" />
    <add key="errorFileWay" value="LogFiles\error.txt" />
  </appSettings>

Значення serializeTo визначає формат кодування, можливі варіанти:(plain/json/soap/xml)
Значення debugFileWay/infoFileWay/warnFileWay/errorFileWay визначає файл збереження повідомлень відповідного рівня логування

LogMessage має наступні поля:

	public string LogLevel;
        public string Message;
        public string Source;
        public string StackTrace;
        public DateTime DateTime;

Публічний інтерфейс має декілька версій перевантаженого метода Log, і дозволяє логувати як явно ініціалізовані лог повідомлення
так і неявно(в цьому випадку DateTime і LogLevel бутуь ініцалізовані неявно)

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
