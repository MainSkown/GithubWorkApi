using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GithubApi.Data;
using GithubApi.Repo;

namespace GithubApi.Service
//Sumary: Just find an existing user
{
    [Route("api/github")]
    [ApiController]
    public class GithubUserController : Controller
    {
        private readonly IGithubRepo _repository;

        public GithubUserController(IGithubRepo repository)
        {
            _repository = repository;
        }

        //GET api/github/{name}
        [HttpGet("{name}")]
        public async Task<ActionResult<UserGithub>> GetUserByName(string name)
        {
            return await _repository.GetUserByName(name);
        }

    }
}
