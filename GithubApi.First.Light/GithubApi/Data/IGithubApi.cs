using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestEase;

namespace GithubApi.Data
{
    [Header("User-Agent", "RestEase")]
    public interface IGithubApi
    {
        [Get("users/{userID}")]
        Task<UserGithub> GetUserAsync([Path] string userID);
    }
}
