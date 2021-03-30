using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stories.Data.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }
    }
}
