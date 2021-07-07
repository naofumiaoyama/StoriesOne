using System;
using System.Collections.Generic;

namespace Stories.Domain.Model
{
    public class PersonalInfo
    {
        public string LoginID { get; set; }
        public string Password { get; set; }
        public string MobileNumber { get; set; }
        public Sex Sex { get; set; }
        public DateTime Birthdate { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string EmailAddress1 { get; set; }
        public string EmailAddress2 { get; set; }
       
        public IDictionary<Guid, Address> Addresses { get; set; }
    }

    public enum Sex
    {
        Male = 1,
        Female = 2,
    }
    public enum MaritalStatus
    {
        Single = 1,
        Married = 2,
        Divorced = 3,
        Windowed = 4,
        Complicated = 5
    }
}
