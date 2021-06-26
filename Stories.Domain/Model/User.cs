using System;
using System.Collections.Generic;

namespace Stories.Domain.Model
{
    public class User : Person
    {
        
        public string DisplayName { get; set; }
        public string SelfIntroction { get; set; }
        public Timeline Timeline { get; set; }
        public Biography Biography { get; set; }

        public List<Story> Stories { get; set; }

        public List<User> Friends { get; set; }

        public Picture ProfilePicture { get; set; }
    }
}
