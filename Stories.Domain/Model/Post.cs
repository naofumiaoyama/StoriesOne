using System;
using System.Collections.Generic;

namespace Stories.Domain.Model
{
    public class Post
    {
        public Post(Guid id, string title, DateTime postDateTime, Story story, IDictionary<Guid, Comment> comments)
        {
            if (Guid.Empty == id)
            {
                throw new ArgumentException("id is a required field.");
            }
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("title is a required field.");
            }

            this.Id = id;
            this.Title = title;
            this.Story = story;
            this.PostDateTime = postDateTime;
            this.Comments = comments;
        }
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public DateTime PostDateTime { get; private set; }
        public Story Story { get; private set; }
        public IDictionary<Guid, Comment> Comments { get; private set; } 
    }
}
