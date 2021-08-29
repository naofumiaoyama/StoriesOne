using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stories.Data.Entities
{
    public class Character : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Story")]
        public Guid StoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
