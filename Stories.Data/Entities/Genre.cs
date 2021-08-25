using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Entities
{
    public class Genre : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public GenreType GenreType { get; set; }
        public ICollection<Story> Stories { get; set; }
    }

    public enum GenreType
    {
        Media = 1,
        Content = 2
    }
}
