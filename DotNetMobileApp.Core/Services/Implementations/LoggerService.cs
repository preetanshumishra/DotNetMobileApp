using System.Diagnostics;
using DotNetMobileApp.Core.Services.Contracts;

namespace DotNetMobileApp.Core.Services.Implementations
{
    public class LoggerService : ILoggerService
    {
        private const string LogPrefix = "[DotNetMobileApp]";
        
        public void LogInfo(string message)
        {
            Debug.WriteLine($"{LogPrefix} [INFO] {message}");
        }
        
        public void LogWarning(string message)
        {
            Debug.WriteLine($"{LogPrefix} [WARNING] {message}");
        }
        
        public void LogError(string message, Exception? exception = null)
        {
            Debug.WriteLine($"{LogPrefix} [ERROR] {message}");
            if (exception != null)
            {
                Debug.WriteLine($"{LogPrefix} [ERROR] Exception: {exception}");
            }
        }
        
        public void LogDebug(string message)
        {
            Debug.WriteLine($"{LogPrefix} [DEBUG] {message}");
        }
    }
}