using System;
namespace Stories.Domain.Model
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string CommentText { get; set; }
        public Person CommentUser { get; set; }
        public DateTime PostTime { get; set; }
    }
}
