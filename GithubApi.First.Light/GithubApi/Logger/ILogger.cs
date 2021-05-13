using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubApi.Logger
{
    public interface ILogger
    {
        void LoggError(string str);
    }
}
