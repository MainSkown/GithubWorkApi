using System;
using System.Net.Http;
using System.Threading.Tasks;
using GithubApi.Data;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace GithubApi.Repo
{
    public class GithubRepo : IGithubRepo
    {
        private readonly string _githubUrl;
        private HttpClient _httpClient;

        public GithubRepo(HttpClient httpClient, IOptions<LinkOptions> url) 
        {
            _httpClient = httpClient;                      

            _githubUrl = url.Value.GithubUrl;
        }

        public async Task<UserGithub> GetUserByName(string name)
        {
            var userJson = await _httpClient.GetStringAsync(new Uri(_githubUrl + name));

            var user = JsonConvert.DeserializeObject<UserGithub>(userJson);

            return user;
        }

        public async Task<User> CreateUser(string name)
        {
            var gitUser = await GetUserByName(name);

            User user = new User()
            {
                Name = gitUser.Name,
                Blog = gitUser.Blog,
                CreatedAt = gitUser.CreatedAt
            };

            return user;
        }        
    }
}
