using GithubApi.Data;
using GithubApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubApi.Controllers
{
    [Route("api/github/list")]
    [ApiController]
    /// Summary: Operates on list for keeping chosen users
    public class GithubListController : ControllerBase
    {
        private readonly IGithubRepo _repository;
        private readonly UserContext _context;

        public GithubListController(IGithubRepo repository, UserContext context)
        {
            _repository = repository;
            _context = context;
        }

        //Get api/github/list
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> ReturnAddedUsers()
        {
            var users = await _context.Users.Select(x => x).ToListAsync();

            return users;
        }
        
        //GET api/github/list/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> ReturnUser(long id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);

            return user;
        }

        //POST api/github/list/{name}
        [HttpPost("{name}")]
        public async Task<ActionResult<User>> CreateUser(string name)
        {
            var user = await _repository.CreateUser(name);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        //PUT api/github/list/{id}/{name}
        [HttpPut("{id}/{name}")]
        public async Task<ActionResult<User>> UpdateUserList(long id, string name)
        {
            var tempUser = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);

            if (tempUser == null)
            {
                return NotFound();
            }

            var user = await _repository.CreateUser(name);

            tempUser.Name = user.Name;
            tempUser.Blog = user.Blog;
            tempUser.CreatedAt = user.CreatedAt;

            await _context.SaveChangesAsync();

            return tempUser;
        }

        //DELETE api/github/list/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if(user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
