using System;
namespace Stories.Domain.Model
{
    public class User : Person
    {
        public string LoginID { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string UserIcon { get; set; }

        public string FirstName { get; set; }
        public string FamiliyName { get; set; }
    }
}
