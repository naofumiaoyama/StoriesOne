using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Domain.Model
{
    public class Person
    {
        public Guid Id{ get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public PersonalInfo PersonalInfo { get; set; }
        public PersonType PersonType { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        
    }

    public enum PersonType
    {
        User = 1,
        SystemOperater = 2,
        Administrator = 3
    }
}
