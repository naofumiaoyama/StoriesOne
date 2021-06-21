using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stories.Data.Entities
{
    public class Person : BaseEntity
    {
        [Key]
        public Guid Id {get; set;}
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public PersonType PersonType { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string SelfIntroduction { get; set; }
        public string LivingPlace { get; set; }
        public string Occupation { get; set; }
        public MaritalStatus MaritalStatus { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public ICollection<Story> Stories { get; set; }

        public ICollection<Post> Posts { get; set; }

        public PersonalInfo PersonalInfo { get; set; }

        public Timeline Timeline { get; set; }
    }
    public enum PersonType
    {
        User = 1,
        SystemOperater = 2,
        Administrator = 3
    }
    public enum MaritalStatus
    {
        Single = 1,
        Married = 2,
        Divorced = 3,
        Windowed = 4,
        Complicated = 5
    }
}
