using System;
using System.Collections.Generic;

namespace Stories.Domain.Model
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Story Story { get; set; }
        public IDictionary<Guid, Comment> Comments { get; set; } 
    }
}
