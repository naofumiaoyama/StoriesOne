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
        public string EmailAddress1 { get; private set; }
        public string EmailAddress2 { get; set; }
        public Address Address{ get; set; }

        public bool IsRequred()
        {
            if(LoginID != EmailAddress1)
            {
                throw new ArgumentNullException("Login-ID and Email-Address do not match.");
            }
            if (string.IsNullOrEmpty(LoginID))
            {
                throw new ArgumentNullException("LoginID is a required field.");
            }
            if (string.IsNullOrEmpty(Password))
            {
                throw new ArgumentNullException("Password is a required field.");
            }
            return true;
        }
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
