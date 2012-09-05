namespace RealWorld.Models
{
    /// <summary>
    /// This is an example of a hypermedia "control" or affordance
    /// </summary>
    public class AppLink
    {
        /// <summary>
        /// This is the link relation to the resource representation being return. It's usually a unique string that the client application can write code against instead of attempting to build URLs. If the link relation is unique to the application, it could take the form of: http://applicationDomain/schema/orderPayment so it can be easily looked by developers. Simple unique strings should not "collide" with the IANA registery of link relations.
        /// </summary>
        public string Rel { get; set; }
        /// <summary>
        /// The uniform interface method to invoke on this link. For HTTP, it could be GET, POST, DELETE, or some such valid HTTP method.
        /// </summary>
        public string Method { get; set; }
        /// <summary>
        /// The resource URI to drive the next step in the interaction.
        /// </summary>
        public string Href { get; set; }
        /// <summary>
        /// Optional short description of the link relationship
        /// </summary>
        public string Description { get; set; }
    }
}