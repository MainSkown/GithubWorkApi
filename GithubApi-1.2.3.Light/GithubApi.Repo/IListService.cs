using GithubApi.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GithubApi.Repo
{
    public interface IListService
    {
        public Task AddUser(User user);
        public Task<bool> DeleteUserFromList(int id);
        public Task<IEnumerable<User>> ReturnAllUsers();
        public Task<User> ReturnUserByID(long id);
        public Task<User> UpdateUser(long id, User user);
    }
}
