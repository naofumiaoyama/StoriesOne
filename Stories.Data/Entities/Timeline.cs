using System;
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
        public Guid PersonId { get; set; }
        public List<Post> Posts { get; set; }
    }
}
