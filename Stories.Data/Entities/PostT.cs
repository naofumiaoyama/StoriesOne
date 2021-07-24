using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stories.Data.Entities
{
    public class PostT : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("TimelineT")]
        public Guid TimelineId { get; set; }
        public string Title { get; set; }
        public DateTime PostDateTime { get; set; }

        public ICollection<PictureT> Pictures { get; set; }
    }
}    

