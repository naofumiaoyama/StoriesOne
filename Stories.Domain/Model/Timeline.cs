using System;
using System.Collections.Generic;

namespace Stories.Domain.Model
{
    public class Timeline
    {
        public Guid PersonId { get; set; }
        public string TimelineName { get; set; }
        public List<Post> Posts { get; set; }
    }
}
