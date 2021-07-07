﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stories.Data.Entities
{
    public class Body : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Story")]
        public Guid StoryId { get; set; }
        public int ChapterNumber { get; set; }
        public string BodyContent { get; set; }
    }
}
