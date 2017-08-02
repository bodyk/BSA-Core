using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreTest.Logging;
using Microsoft.Extensions.Logging;

namespace CoreTest.Extensions
{
    public static class CustomConsoleLoggerExtensions
    {
        public static ILoggerFactory AddCustomConsoleLogger(this ILoggerFactory loggerFactory, CustomConsoleLoggerConfiguration config)
        {
            loggerFactory.AddProvider(new CustomConsoleLoggerProvider(config));
            return loggerFactory;
        }
        public static ILoggerFactory AddCustomConsoleLogger(this ILoggerFactory loggerFactory)
        {
            var config = new CustomConsoleLoggerConfiguration();
            return loggerFactory.AddCustomConsoleLogger(config);
        }
        public static ILoggerFactory AddCustomConsoleLogger(this ILoggerFactory loggerFactory, Action<CustomConsoleLoggerConfiguration> configure)
        {
            var config = new CustomConsoleLoggerConfiguration();
            configure(config);
            return loggerFactory.AddCustomConsoleLogger(config);
        }
    }
}
