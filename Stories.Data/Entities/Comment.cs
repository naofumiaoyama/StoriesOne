using System;
using System.ComponentModel.DataAnnotations;

namespace Stories.Data.Entities
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }
        public Post Post { get; set; }
        public string CommentText { get; set; }
        public Person CommentUser  { get; set; }
        public DateTime PostTime { get; set; }
    }
}
