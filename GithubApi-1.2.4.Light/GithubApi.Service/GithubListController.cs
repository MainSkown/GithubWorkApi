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
    public class GithubListController : ControllerBase
    {
        private readonly IListService _listService;                
        public GithubListController(IListService listService)
        {            
           _listService = listService;
        }
           
        
        //Get api/github/list
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> ReturnAddedUsers()
        {
            var users = await _listService.ReturnAllUsers();

            //Need to state this like this, because it makes error otherwise
            return users.ToList();
        }
        
        //GET api/github/list/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> ReturnUser(long id)
        {
            var user = await _listService.ReturnUserByID(id);

            return user;
        }

        //POST api/github/list/{name}
        [HttpPost("{name}")]
        public async Task<ActionResult<User>> CreateUser(string name)
        {
            var user = await _listService.CreateUser(name);

            return user;
        }

        //PUT api/github/list/{id}/{name}
        [HttpPut("{id}/{name}")]
        public async Task<ActionResult> UpdateUserList(long id, string name)
        {
            await _listService.UpdateUserList(id, name);

            return NoContent();
        }

        //DELETE api/github/list/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _listService.DeleteUser(id);      
           
            return NoContent();
        }

    }
}
