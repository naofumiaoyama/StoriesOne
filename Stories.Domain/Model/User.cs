using System;
namespace Stories.Domain.Model
{
    public class User
    {
        public Guid ID { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public PersonInfo PersonInfo { get; set; }
        public string LoginID { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string UserIconURL { get; set; }
        public string SelfIntroction { get; set; }
        public string GroupName { get; set; }
    }
}
