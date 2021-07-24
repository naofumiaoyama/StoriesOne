using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stories.Data.Entities
{
    public class PersonT : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public PersonType PersonType { get; set; }
        public string DisplayName { get; set; }
        public string SelfIntroduction { get; set; }
        public string LivingPlace { get; set; }
        public string Occupation { get; set; }
        public PictureT ProfilePicture { get; set; }
        public TimelineT Timeline { get; set; }
        public ICollection<FriendRelationshipT> FriendRelationships { get; set; }

        public ICollection<StoryT> Stories { get; set; }

    }

    public enum PersonType
    {
        User = 1,
        SystemOperater = 2,
        Administrator = 3
    }
}
