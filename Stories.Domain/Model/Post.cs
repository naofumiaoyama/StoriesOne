using System;
using System.Collections.Generic;

namespace Stories.Domain.Model
{
    public class Post
    {
        public Post(Guid id, string title)
        {
            if (Guid.Empty == id)
            {
                throw new ArgumentException("id is a required field.");
            }
            if (title == null)
            {
                throw new ArgumentException("title is null.");
            }
            this.Id = id;
            this.Title = title;
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime PostDateTime { get; set; }
        public Story Story { get; set; }
        public IDictionary<Guid, Comment> Comments { get; set; } 
    }
}
