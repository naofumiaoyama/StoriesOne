using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stories.Data.Entities
{
    public class Comment : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Post")]
        public Guid PostId { get; set; }
        public string CommentText { get; set; }
        public DateTime PostTime { get; set; }
    }
}
