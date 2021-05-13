using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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
