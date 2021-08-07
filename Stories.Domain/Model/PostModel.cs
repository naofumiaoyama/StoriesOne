using System;
using System.Collections.Generic;

namespace Stories.Domain.Model
{
    public class PostModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public StoryModel Story { get; set; }
        public IDictionary<Guid, CommentModel> Comments { get; set; } 
    }
}
