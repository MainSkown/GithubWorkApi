using GithubApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GithubApi.Repo.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> opt) : base(opt)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
