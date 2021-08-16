using System;
using System.Collections.Generic;

namespace Stories.Domain.Model
{
    public class Post
    {
        public Post(Guid id, string title, Story story)
        {
            if (Guid.Empty == id)
            {
                throw new ArgumentException("id is a required field.");
            }
            if (story == null)
            {
                throw new ArgumentException("Story is null.");
            }
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Story Story { get; set; }
        public IDictionary<Guid, Comment> Comments { get; set; } 
    }
}
