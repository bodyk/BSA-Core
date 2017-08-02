using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CoreTest.Logging
{
    public class CustomConsoleLoggerProvider : ILoggerProvider
    {
        private readonly CustomConsoleLoggerConfiguration _config;
        private readonly ConcurrentDictionary<string, CustomConsoleLogger> _loggers = new ConcurrentDictionary<string, CustomConsoleLogger>();
        public CustomConsoleLoggerProvider(CustomConsoleLoggerConfiguration config)
        {
            _config = config;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, name => new CustomConsoleLogger(name, _config));
        }
        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}
