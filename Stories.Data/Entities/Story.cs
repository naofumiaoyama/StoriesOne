﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stories.Data.Entities
{
    public class Story : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Person")]
        public Guid PersonId { get; set; }
        public StoryType StoryType { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Thoughts { get; set; }
        [ForeignKey("Genre")]
        public Guid GenreId { get; set; }
        public ICollection<Chapter> Chapters { get; set; }
        public Post Post { get; set; }
    }

    public enum StoryType
    {
        WellKnown = 1,
        Original = 2
    }
}
