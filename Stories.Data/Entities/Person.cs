using System;
using System.ComponentModel.DataAnnotations;

namespace Stories.Data.Entities
{
    public class Person
    {
        [Key]
        public Guid Id {get; set;}
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string SelfIntroduction { get; set; }

    }
}
