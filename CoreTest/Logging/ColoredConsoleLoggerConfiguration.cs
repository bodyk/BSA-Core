using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CoreTest.Logging
{
    public class ColoredConsoleLoggerConfiguration
    {
        public LogLevel LogLevel { get; set; } = LogLevel.Information;
        public int EventId { get; set; } = 0;
        public ConsoleColor Color { get; set; } = ConsoleColor.Yellow;
    }
}
