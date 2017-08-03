using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreTest.Logging;
using Microsoft.Extensions.Logging;

namespace CoreTest.Extensions
{
    public static class CustomLoggerExtensions
    {
        public static ILoggerFactory AddCustomLogger(this ILoggerFactory loggerFactory, CustomLoggerConfiguration config)
        {
            loggerFactory.AddProvider(new CustomLoggerProvider(config));
            return loggerFactory;
        }
        public static ILoggerFactory AddCustomLogger(this ILoggerFactory loggerFactory)
        {
            var config = new CustomLoggerConfiguration();
            return loggerFactory.AddCustomLogger(config);
        }
        public static ILoggerFactory AddCustomLogger(this ILoggerFactory loggerFactory, Action<CustomLoggerConfiguration> configure)
        {
            var config = new CustomLoggerConfiguration();
            configure(config);
            return loggerFactory.AddCustomLogger(config);
        }
    }
}
