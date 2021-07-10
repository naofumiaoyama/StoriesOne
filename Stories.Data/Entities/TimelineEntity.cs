using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Entities
{
   public class TimelineEntity : BaseEntity
    {
        [Key]
        [ForeignKey("PersonEntity")]
        public Guid PersonId { get; set; }
        public string TimelineName { get; set; }
        public ICollection<PostEntity> Posts { get; set; }
    }
}
