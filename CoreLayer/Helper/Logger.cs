using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CoreLayer.Helper
{
    public static class Logger
    {
        private static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddConsole()                
                .SetMinimumLevel(LogLevel.Information); 
        });

        private static readonly ILogger _logger = _loggerFactory.CreateLogger("AutomationLogger");

        public static void Info(string message) => _logger.LogInformation(message);

        public static void Warn(string message) => _logger.LogWarning(message);

        public static void Error(string message, Exception? ex = null)
        {
            if (ex != null)
                _logger.LogError(ex, message);
            else
                _logger.LogError(message);
        }

        public static void Debug(string message) => _logger.LogDebug(message);
    }
}
