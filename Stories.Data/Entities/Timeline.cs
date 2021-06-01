﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Entities
{
   public class Timeline
    {
        [Key]
        public Guid Id { get; set; }
        public Person Person { get; set; }
    }
}
