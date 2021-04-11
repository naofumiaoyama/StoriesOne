using System;
namespace Stories.Domain.Model
{
    public class Person
    {
        public Guid ID {get;set;}
        public string GivenName { get; set;}
        public string FamilyName{ get; set; }
        public PersonInfo PersonInfo { get; set; }

    }
}
