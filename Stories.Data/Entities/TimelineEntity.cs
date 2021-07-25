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
        public Guid Id { get; set; }
        [ForeignKey("PersonEntity")]
        public Guid OwnerPersonId { get; set; }
        public string TimelineName { get; set; }
        public ICollection<PostEntity> Posts { get; set; }
    }
}
