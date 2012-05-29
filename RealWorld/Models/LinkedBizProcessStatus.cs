using System.Collections.Generic;

namespace RealWorld.Models
{
    public class LinkedBizProcessStatus
    {
        public string Status { get; set; }
        public IEnumerable<AppLink> ProcessingDetails { get; set; }
    }
}