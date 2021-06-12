using System;
namespace Stories.Domain.Model
{
    public class User : Person
    {
        public string LoginID { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public Picture UserIconPicture { get; set; }
        public string SelfIntroction { get; set; }
        public string GroupName { get; set; }
        public Timeline Timeline { get; set; }
        public Biography Biography { get; set; }
    }
}
