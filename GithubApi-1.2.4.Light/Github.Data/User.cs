using System;

namespace GithubApi.Data
{    
   public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Blog { get; set; }
        public DateTime CreatedAt { get; set; }
    }    
}
