using GithubApi.Data;
using System.Threading.Tasks;

namespace GithubApi.Repo
{
    //Only use when IGithubApi needed
    public interface IGithubRepo
    {     
        Task<UserGithub> GetUserByName(string name);
        
        Task<User> CreateUser(string name);
    }
}
