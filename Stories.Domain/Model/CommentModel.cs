using System;
namespace Stories.Domain.Model
{
    public class CommentModel
    {
        public Guid Id { get; set; }
        public string CommentText { get; set; }
        public PersonModel CommentUser { get; set; }
        public DateTime PostTime { get; set; }
    }
}
