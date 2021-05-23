using System;
namespace Stories.Domain.Model
{
    public class User : Person
    {
        public string LoginID { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string UserIconURL { get; set; }
        public string SelfIntroction { get; set; }
        public string GroupName { get; set; }
        public Timeline timeline { get; set; }
    }
}
