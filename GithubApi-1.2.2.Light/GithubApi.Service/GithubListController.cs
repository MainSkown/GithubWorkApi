using GithubApi.Data;
using GithubApi.Repo;
using GithubApi.Repo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubApi.Service
{
    [Route("api/github/list")]
    [ApiController]
    /// Summary: Operates on list for keeping chosen users
    public class GithubListController : ListService
    {
        private readonly IGithubRepo _repository;
        public GithubListController(IGithubRepo repository, UserContext context) : base(context)
        {
            _repository = repository;
        }
           
        
        //Get api/github/list
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> ReturnAddedUsers()
        {
            var users = await ReturnAllUsers();

            //Need to state this like this, because it makes error otherwise
            return users.ToList();
        }
        
        //GET api/github/list/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> ReturnUser(long id)
        {
            var user = await ReturnUserByID(id);

            return user;
        }

        //POST api/github/list/{name}
        [HttpPost("{name}")]
        public async Task<ActionResult<User>> CreateUser(string name)
        {
            var user = await _repository.CreateUser(name);

            await AddUser(user);            

            return user;
        }

        //PUT api/github/list/{id}/{name}
        [HttpPut("{id}/{name}")]
        public async Task<ActionResult<User>> UpdateUserList(long id, string name)
        {           
            var user = await _repository.CreateUser(name);

            var tempUser = await UpdateUser(id, user);

            if(tempUser == null)
            {
                return NotFound();
            }
            

            return tempUser;
        }

        //DELETE api/github/list/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            bool succeed = await DeleteUserFromList(id);

            if (succeed == false)
            {
                return NotFound();
            }           
           
            return NoContent();
        }

    }
}
