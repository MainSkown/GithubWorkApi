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
        private HttpClient httpClient;

        public GithubRepo(IHttpClientFactory clientFactory, IOptions<LinkOptions> url) 
        {                     
            httpClient = clientFactory.CreateClient();

            httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");

            _githubUrl = url.Value.GithubUrl;
        }

        public async Task<UserGithub> GetUserByName(string name)
        {
            var userJson = await httpClient.GetStringAsync(new Uri(_githubUrl + name));

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
