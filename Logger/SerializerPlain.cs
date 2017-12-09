using System.IO;

namespace Logger
{
    class SerializerPlain : IImplementable
    {
        public void ConvertToFile(string fileWay, LogMessage currentMessage)
        {
            // Append text to an existing file
            using (StreamWriter outputFile = new StreamWriter(fileWay, true))
            {
                outputFile.WriteLine($"{currentMessage.LogLevel} LogMessage was generated at: {currentMessage.DateTime}");
                outputFile.WriteLine($"Message: {currentMessage.Message}");
                if (currentMessage.Source != null)
                {
                    outputFile.WriteLine($"Source: {currentMessage.Source}");
                }
                if (currentMessage.StackTrace != null)
                {
                    outputFile.WriteLine($"StackTrace: {currentMessage.StackTrace}");
                }
                outputFile.WriteLine();
                outputFile.WriteLine();
                outputFile.WriteLine();
            }
        }
    }
}
