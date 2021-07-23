using System;
using System.Collections.Generic;

namespace Stories.Domain.Model
{
    public class PersonalInfo
    {
        public PersonalInfo(string loginId, string password, string emailAddress1)
        {
            LoginID = loginId;
            Password = password;
            EmailAddress1 = emailAddress1;

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("loginId is required as an argument.");
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("password is required as an argument.");
            }
            if (string.IsNullOrEmpty(emailAddress1))
            {
                throw new ArgumentNullException("emailAddress1 is required as an argument.");
            }
            if ( loginId != emailAddress1)
            {
                throw new ArgumentException("loginId and emailAddress1 must be the same.");
            }
        }

        public string LoginID { get; private set; }
        public string Password { get; private set; }
        public string MobileNumber { get; set; }
        public Sex Sex { get; set; }
        public DateTime Birthdate { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string EmailAddress1 { get; private set; }
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
