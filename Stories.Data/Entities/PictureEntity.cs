using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Stories.Data.Entities
{
    public class PictureEntity : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public PictureOwnerType PictureOwnerType { get; set; }
        public string Url { get; set; }
    }

    public enum PictureOwnerType
    {
        Person = 1,
        Post = 2,
        Story = 3
    }
}
