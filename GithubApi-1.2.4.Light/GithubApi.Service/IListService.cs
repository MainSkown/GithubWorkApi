using GithubApi.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GithubApi.Service
{
    public interface IListService
    {
        Task<IEnumerable<User>> ReturnAllUsers();
        Task<User> ReturnUserByID(long id);
        Task<User> CreateUser(string name);
        Task UpdateUserList(long id, string name);
        Task DeleteUser(int id);
    }
}
