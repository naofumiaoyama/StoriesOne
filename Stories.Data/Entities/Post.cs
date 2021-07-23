using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stories.Data.Entities
{
    public class Post : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Timeline")]
        public Guid TimelineId { get; set; }
        [ForeignKey("Picture")]
        public Guid PictureId { get; set; }
        public string Title { get; set; }
        public DateTime PostDateTime { get; set; }   
    }
}    

