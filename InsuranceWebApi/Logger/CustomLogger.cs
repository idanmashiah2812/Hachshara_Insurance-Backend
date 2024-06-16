using Serilog;
using System.Text;
using ILogger = Serilog.ILogger;

namespace InsuranceWebApi.Logger
{
    public class CustomLogger
    {
        private static readonly Lazy<CustomLogger> lazyLogger = new(() => new CustomLogger());
        public static CustomLogger Instance => lazyLogger.Value;

        private readonly ILogger _logger;
        private CustomLogger()
        {
            _logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("cv-app-logs/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public void Error(string errorMessage, Exception? exception = null, string className = "", string functionName = "")
        {
            var customErrMessage = new StringBuilder();
            if (!string.IsNullOrEmpty(className))
                customErrMessage.Append(className + " -> ");

            if (!string.IsNullOrEmpty(functionName))
                customErrMessage.Append(functionName + " -> ");

            customErrMessage.Append(errorMessage);

            _logger.Error(customErrMessage.ToString(), exception);
        }

        public void Info(string message)
        {
            _logger.Information(message);
        }
    }
}
