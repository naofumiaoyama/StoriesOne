using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Domain.Model
{
    public class Person
    {
        public Guid ID { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public PersonInfo PersonInfo { get; set; }
        
    }
}
