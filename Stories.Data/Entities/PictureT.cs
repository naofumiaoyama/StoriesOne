using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Stories.Data.Entities
{
    public class PictureT : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public PictureType PictureType { get; set; }
        public string Url { get; set; }
    }

    public enum PictureType
    {
        UserProfile = 1,
        Post = 2,
        Story = 3
    }
}
