using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Entities
{
    public class Story
    {
        public Guid Id  { get; set; }
        public string Title { get; set; }
        public Person Author { get; set; }
        public string Summary { get; set; }
        public Guid CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
