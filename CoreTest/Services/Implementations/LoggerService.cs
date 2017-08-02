using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CoreTest.Services.Implementations
{
    public class LoggerService
    {
        private readonly ILogger _logger;

        public LoggerService(ILogger logger)
        {
            _logger = logger;
        }

        public void LogInformation(EventId eventId, string message)
        {
            _logger.LogInformation(eventId, message);
        }
    }
}
