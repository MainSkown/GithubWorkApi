using GithubApi.Data;
using GithubApi.Repo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GithubApi.Repo
{
    public interface IListRepo
    {
        UserContext context { get; }
        Task AddUser(User user);
        Task<bool> DeleteUserFromList(int id);
        Task<IEnumerable<User>> ReturnAllUsers();
        Task<User> ReturnUserByID(long id);
        Task<User> UpdateUser(long id, User user);
    }
}
