Logger - ��������� ������ �� ���� ��������� ����� ����� dll ��� ����� ��������� � ����� ������
TestApp - ������������ ������ ������
������������ ������ (��������� nlog) ���������� ���������� �� ����� ������������ App.config ���������� ����:

  <appSettings>
    <add key="serializeTo" value="plain" />
    <add key="debugFileWay" value="LogFiles\debug.txt" />
    <add key="infoFileWay" value="LogFiles\info.txt" />
    <add key="warnFileWay" value="LogFiles\warn.txt" />
    <add key="errorFileWay" value="LogFiles\error.txt" />
  </appSettings>

�������� serializeTo ������� ������ ���������, ������ �������:(plain/json/soap/xml)
�������� debugFileWay/infoFileWay/warnFileWay/errorFileWay ������� ���� ���������� ���������� ���������� ���� ���������

LogMessage �� ������� ����:

	public string LogLevel;
        public string Message;
        public string Source;
        public string StackTrace;
        public DateTime DateTime;

�������� ��������� �� ������� ����� ��������������� ������ Log, � �������� �������� �� ���� ����������� ��� �����������
��� � ������(� ����� ������� DateTime � LogLevel ����� ���������� ������)

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