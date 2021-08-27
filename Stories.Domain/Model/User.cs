using System;
using System.Collections.Generic;

namespace Stories.Domain.Model
{
    public class User : Person
    {
        public User(Guid id,
            string firstName,
            string lastName,
            string nickName,
            PersonalInfo personalInfo,
            PersonType personType,
            string displayName,
            string selfIntroduction,
            string livingPlace,
            string occupation,
            IDictionary<Guid, Story> stories,
            IDictionary<Guid, User> friends,
            Picture profilePicture) :
            base(id, firstName, lastName, nickName, personalInfo, personType)
        {
            DisplayName = displayName;
            SelfIntroduction = selfIntroduction;
            LivingPlace = livingPlace;
            Occupation = occupation;
            Stories = stories;
            Friends = friends;
            ProfilePicture = profilePicture;
        }
        public string DisplayName { get; private set; }
        public string SelfIntroduction { get; private set; } 
        public string LivingPlace { get; private set; }
        public string Occupation { get; private set; }
        public IDictionary<Guid, Story> Stories { get; private set; }
        public IDictionary<Guid, User> Friends { get; private set; }
        public Picture ProfilePicture { get; private set; }
    }
}
