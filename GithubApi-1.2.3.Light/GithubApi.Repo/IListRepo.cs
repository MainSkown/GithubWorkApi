using GithubApi.Data;
using System.Threading.Tasks;

namespace GithubApi.Repo
{
    public interface IListRepo
    {
        Task<User> CreateUser(string name);
        Task UpdateUserList(long id, string name);
        Task DeleteUser(int id);
    }
}
