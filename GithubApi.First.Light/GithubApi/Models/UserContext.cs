using GithubApi.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubApi.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> opt) : base(opt)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
