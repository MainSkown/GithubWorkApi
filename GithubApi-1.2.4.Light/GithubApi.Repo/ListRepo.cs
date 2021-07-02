using GithubApi.Data;
using GithubApi.Repo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GithubApi.Repo
{
    public class ListRepo : IListRepo
    {
        private readonly UserContext _context;
        
        public ListRepo(UserContext listContext)
        {
            _context = listContext;
        }
        UserContext IListRepo.context => _context;

        public async Task AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();           
        }

        public async Task<bool> DeleteUserFromList(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if(user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<User>> ReturnAllUsers()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }       

        public async Task<User> ReturnUserByID(long id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);

            return user;
        }

        public async Task<User> UpdateUser(long id, User user)
        {
            var tempUser = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);

            if(tempUser == null)
            {
                return null;
            }

            tempUser.Name = user.Name;
            tempUser.Blog = user.Blog;
            tempUser.CreatedAt = user.CreatedAt;

            await _context.SaveChangesAsync();

            return tempUser;
        }
    }
}
