using System;
using System.Collections.Generic;

namespace Stories.Domain.Model
{
    public class Timeline
    {
        public Guid PersonId { get; set; }
        public string TimelineName { get; set; }
        public IDictionary<Guid, Post> Posts { get; set; }
    }
}
