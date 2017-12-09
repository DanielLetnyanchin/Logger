using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;

namespace Logger
{
    class SerializerSoap : IImplementable
    {
        public void ConvertToFile(string fileWay, LogMessage currentMessage)
        {
            // Append text to an existing file
            using (FileStream outputFile = new FileStream(fileWay, FileMode.Append, FileAccess.Write, FileShare.Read))
            {
                SoapFormatter soapForamt = new SoapFormatter();
                soapForamt.Serialize(outputFile, currentMessage);

                //outputFile.Write();
                byte[] info = new UTF8Encoding(true).GetBytes("\r\n\r\n\r\n\r");
                outputFile.Write(info, 0, info.Length);
            }
        }
    }
}
