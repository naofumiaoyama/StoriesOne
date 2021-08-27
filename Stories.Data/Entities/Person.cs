using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stories.Data.Entities
{
    public class Person : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string DisplayName { get; set; }
        public string SelfIntroduction { get; set; }
        public string LivingPlace { get; set; }
        public string Occupation { get; set; }
        public PersonType PersonType { get; set; }
        public PersonalInfo PersonalInfo { get; set; }

        public ICollection<FriendRelationship> FriendRelationships { get; set; }
        public ICollection<Story> Stories { get; set; }

    }

    public enum PersonType
    {
        User = 1,
        SystemOperater = 2,
        Administrator = 3
    }
}
