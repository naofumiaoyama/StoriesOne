using System;
namespace Stories.Domain.Model
{
    public class Person
    {
        public string ID {get;set;}
        public string GivenName { get; set;}
        public string FamilyName{ get; set; }
        public PersonInfo PersonInfo { get; set; }

    }
}
