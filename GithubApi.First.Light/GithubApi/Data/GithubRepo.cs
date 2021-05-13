using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GithubApi.Models;
using RestEase;

namespace GithubApi.Data
{
    public class GithubRepo : IGithubRepo
    {
        //Could add it by DI but I don't think it's a big deal
        private readonly IGithubApi _githubApi = RestClient.For<IGithubApi>("https://api.github.com");

        public async Task<User> CreateUser(string name)
        {
            var userTDO = _githubApi.GetUserAsync(name).Result;

            var user = new User
            {
                Name = userTDO.Name,
                Blog = userTDO.Blog,
                CreatedAt = userTDO.CreatedAt
            };

            return user;
        }        

        public async Task<UserGithub> GetUserByName(string name)
        {
            var user = _githubApi.GetUserAsync(name).Result;
            return user;
        }        
    }
}
