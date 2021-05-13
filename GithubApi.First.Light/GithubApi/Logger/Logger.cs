using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace GithubApi.Logger
{
    public class Logger : ILogger
    {              
        public void LoggError(string str)
        {
            var log = new LoggerConfiguration().WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
            log.Information(str);                        
        }
    }
}
