﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stories.Data.Entities
{
    public class PostEntity : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("TimelineEntity")]
        public Guid TimelineId { get; set; }
        [ForeignKey("PictureEntity")]
        public Guid PictureId { get; set; }
        public string Title { get; set; }
        public DateTime PostDateTime { get; set; }   
    }
}    

