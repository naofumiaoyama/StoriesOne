using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Entities
{
   public class Notification
   {
        [Key]
        public Guid Id { get; set; }
        public Picture DispImage { get; set; }
        public string Contents { get; set; }
        public string UrlLink { get; set; }
   }
}
