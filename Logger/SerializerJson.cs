using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Logger
{
    class SerializerJson : IImplementable
    {
        public void ConvertToFile(string fileWay, LogMessage currentMessage)
        {
            // Append text to an existing file
            using (FileStream outputFile = new FileStream(fileWay, FileMode.Append, FileAccess.Write, FileShare.Read))
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(LogMessage));
                jsonFormatter.WriteObject(outputFile, currentMessage);

                byte[] info = new UTF8Encoding(true).GetBytes("\r\n\r\n\r\n\r");
                outputFile.Write(info, 0, info.Length);
            }
        }
    }
}
