using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Entities
{
    public class Biography
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Occupation { get; set; }
        public string MaritalStatus { get; set; }
    }

    public enum MaritalStatus
    {
        SINGLE,
        MARRIED,
        DIVORCED,
        WIDOWED,
        COMPLICATED
    }        
}
