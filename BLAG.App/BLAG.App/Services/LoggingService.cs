using System.Diagnostics;
using Splat;

namespace BLAG.App.Services
{
    public class LoggingService : ILogger
    {
        public LogLevel Level { get; set; }

        public void Write(string message, LogLevel logLevel)
        {
            if ((int) logLevel < (int) Level) return;

            Debug.WriteLine(message);
        }
    }
}