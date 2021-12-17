using System;
using Newtonsoft.Json;

namespace GithubApi.Data
{
    public class UserGithub
    {
        public string Name { get; set; }
        public string Blog { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
