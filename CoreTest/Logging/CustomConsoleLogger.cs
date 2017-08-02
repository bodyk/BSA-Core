using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
                Debug.WriteLine($"CUSTOM LOG: {state.ToString()}");
            }
        }
    }
}
