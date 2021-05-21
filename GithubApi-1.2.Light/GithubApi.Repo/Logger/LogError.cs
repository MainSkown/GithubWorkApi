using GithubApi.Data;
using Microsoft.Extensions.Options;
using Serilog;

namespace GithubApi.Repo.Logger
{
    public class LogError : ILogError
    {
        private readonly ILogger _logger;
        private readonly string _logPath;

        public LogError(IOptions<LinkOptions> options, ILogger logger)
        {
            _logger = logger;
            _logPath = options.Value.LogPath;
        }

        public void LoggError(string str)
        {            
            _logger.Information(str);                        
        }
    }
}
