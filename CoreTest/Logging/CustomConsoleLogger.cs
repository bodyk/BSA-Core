using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators.Internal;
using Microsoft.Extensions.Logging;

namespace CoreTest.Logging
{
    public class CustomConsoleLogger : ILogger
    {
        private readonly string _name;
        private readonly CustomConsoleLoggerConfiguration _config;
        public CustomConsoleLogger(string name, CustomConsoleLoggerConfiguration config)
        {
            _name = name;
            _config = config;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == _config.LogLevel;
        }
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }
            if (_config.EventId == 0 || _config.EventId == eventId.Id)
            {
                // It is possible to watch log in file and also in debug window
                LogMessageToFile($"CUSTOM LOG: {state.ToString()}");
                Debug.WriteLine($"CUSTOM LOG: {state.ToString()}");
            }
        }

        private void LogMessageToFile(string msg)
        {
            try
            {
                if (!String.IsNullOrEmpty(_config.FilePath))
                {
                    File.AppendAllLines(_config.FilePath, new[] { msg });
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}
