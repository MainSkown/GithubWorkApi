using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubApi.Data
{
    //Only use when IGithubApi needed
    public interface IGithubRepo
    {     
        Task<UserGithub> GetUserByName(string name);
        
        Task<User> CreateUser(string name);
    }
}
