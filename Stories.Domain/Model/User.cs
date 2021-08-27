using System;
using System.Collections.Generic;

namespace Stories.Domain.Model
{
    public class User : Person
    {
        public User(Guid id, string firstName, string lastName, PersonType personType)
        {
            if (Guid.Empty == id)
            {
                throw new ArgumentException("id is a required field.");
            }
            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentException("firstName is a required field.");
            }
            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentException("lastName is a required field.");
            }
            if (!PersonType.IsDefined(personType))
            {
                throw new ArgumentException("The personType has not been defined.");
            }

            base.Id = id;
            base.FirstName = firstName;
            base.LastName = lastName;
            base.PersonType = personType;
        }
        public string DisplayName { get; set; }
        public string SelfIntroction { get; set; } 
        public string LivingPlace { get; set; }
        public string Occupation { get; set; }
        public IDictionary<Guid, Story> Stories { get; set; }
        
        public IDictionary<Guid, User> Friends { get; set; }

        public Picture ProfilePicture { get; set; }

    }
}
