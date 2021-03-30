using System;
using System.ComponentModel.DataAnnotations;

namespace Stories.Data.Entities
{
    public class Person
    {
        public Guid Id {get; set;}
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
    }
}
