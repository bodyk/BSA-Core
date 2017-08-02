﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreTest.Logging;
using Microsoft.Extensions.Logging;

namespace CoreTest.Extensions
{
    public static class ColoredConsoleLoggerExtensions
    {
        public static ILoggerFactory AddColoredConsoleLogger(this ILoggerFactory loggerFactory, ColoredConsoleLoggerConfiguration config)
        {
            loggerFactory.AddProvider(new ColoredConsoleLoggerProvider(config));
            return loggerFactory;
        }
        public static ILoggerFactory AddColoredConsoleLogger(this ILoggerFactory loggerFactory)
        {
            var config = new ColoredConsoleLoggerConfiguration();
            return loggerFactory.AddColoredConsoleLogger(config);
        }
        public static ILoggerFactory AddColoredConsoleLogger(this ILoggerFactory loggerFactory, Action<ColoredConsoleLoggerConfiguration> configure)
        {
            var config = new ColoredConsoleLoggerConfiguration();
            configure(config);
            return loggerFactory.AddColoredConsoleLogger(config);
        }
    }
}
