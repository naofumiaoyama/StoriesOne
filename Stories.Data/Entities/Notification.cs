using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stories.Data.Entities
{
   public class Notification : BaseEntity
   {
        [Key]
        public Guid Id { get; set; }
        public Picture DispImage { get; set; }
        public string Contents { get; set; }
        public string UrlLink { get; set; }
   }
}
