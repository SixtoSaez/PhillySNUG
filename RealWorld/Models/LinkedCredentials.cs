using System.Collections.Generic;

namespace RealWorld.Models
{
    public class LinkedCredentials
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public IEnumerable<AppLink> Links { get; set; }
    }
}