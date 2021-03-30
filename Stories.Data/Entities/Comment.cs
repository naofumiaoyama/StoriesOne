using System;
using System.ComponentModel.DataAnnotations;

namespace Stories.Data.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public User CommentUser  { get; set; }
        public DateTime PostTime { get; set; }
    }
}
