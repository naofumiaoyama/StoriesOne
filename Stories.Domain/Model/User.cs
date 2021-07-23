using System;
using System.Collections.Generic;

namespace Stories.Domain.Model
{
    public class User : Person
    {

        public string DisplayName { get; set; }
        public string SelfIntroction { get; set; }
        public Timeline Timeline { get; set; }
        public string LivingPlace { get; set; }
        public string Occupation { get; set; }
        public IDictionary<Guid, Story> Stories { get; set; }
        
        public IDictionary<Guid, User> Friends { get; set; }

        public Picture ProfilePicture { get; set; }
    }
}
