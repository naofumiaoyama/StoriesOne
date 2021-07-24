﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stories.Data.Entities
{
    public class StoryT : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("PersonT")]
        public Guid AuthorPersonId { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }

        public ICollection<BodyT> Bodies { get; set; }

    }
}