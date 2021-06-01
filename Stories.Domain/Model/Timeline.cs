using System;
using System.Collections.Generic;

namespace Stories.Domain.Model
{
    public class Timeline
    {
        public Guid Id { get; set; }
        public List<Post> Posts { get; set; }
    }
}
