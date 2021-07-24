using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stories.Data.Entities
{
    public class CommentT : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("PostT")]
        public Guid PostId { get; set; }
        public Guid CommentPersonId { get; set; }
        public string CommentText { get; set; }
        public DateTime PostTime { get; set; }
    }
}
