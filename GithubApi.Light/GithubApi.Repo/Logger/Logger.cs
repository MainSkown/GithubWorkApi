using GithubApi.Data;
using Microsoft.Extensions.Options;
using Serilog;

namespace GithubApi.Repo.Logger
{
    public class Logger : ILogger
    {              
        private readonly string _logPath;

        public Logger(IOptions<LinkOptions> options)
        {
            _logPath = options.Value.LogPath;
        }

        public void LoggError(string str)
        {
            var log = new LoggerConfiguration().WriteTo.File(_logPath, rollingInterval: RollingInterval.Day).CreateLogger();
            log.Information(str);                        
        }
    }
}
