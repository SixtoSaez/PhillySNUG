using System.Collections.Generic;

namespace RealWorld.Areas.Rest.Models
{
    /// <summary>
    /// The representation of the application credentials resource
    /// </summary>
    public class LinkedCredentials
    {
        /// <summary>
        /// User name registered for use by this API
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// The user password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// The list of links to the potential next steps for this user
        /// </summary>
        public IEnumerable<AppLink> Links { get; set; }
    }
}