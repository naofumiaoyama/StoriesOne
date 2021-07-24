using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Entities
{
   public class TimelineT : BaseEntity
    {
        [Key]
        [ForeignKey("PersonT")]
        public Guid PersonId { get; set; }
        public string TimelineName { get; set; }
        public ICollection<PostT> Posts { get; set; }
    }
}
