using System.IO;
using System.Xml.Serialization;

namespace Logger
{
    class SerializerXml : IImplementable
    {
        public void ConvertToFile(string fileWay, LogMessage currentMessage)
        {
            // Append text to an existing file
            using (StreamWriter outputFile = new StreamWriter(fileWay, true))
            {
                XmlSerializer xmlForamt = new XmlSerializer(typeof(LogMessage));
                xmlForamt.Serialize(outputFile, currentMessage);

                outputFile.WriteLine();
                outputFile.WriteLine();
                outputFile.WriteLine();
                outputFile.WriteLine();
            }
        }
    }
}
