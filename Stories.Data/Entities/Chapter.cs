using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stories.Data.Entities
{
    public class Chapter : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Story")]
        public Guid StoryId { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
