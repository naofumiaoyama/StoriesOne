using System;
namespace Stories.Domain.Model
{
    public class Comment
    {
        public Comment(Guid id, string commentText, DateTime postTime)
        {
            if (Guid.Empty == id)
            {
                throw new ArgumentException("id is a required field.");
            }
            if (string.IsNullOrEmpty(commentText))
            {
                throw new ArgumentException("commentText is a required field.");
            }
            if (postTime == DateTime.MinValue)
            {
                throw new ArgumentException("postTime can't be minvalue");
            }

            this.Id = id;
            this.CommentText = commentText;
            this.PostTime = postTime;
        }
        public Guid Id { get; private set; }
        public string CommentText { get; private set; }
        public DateTime PostTime { get; private set; }
    }
}
