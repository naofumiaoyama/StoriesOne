using System;
using System.Collections.Generic;
using Stories.Utility;

namespace Stories.Domain.Model
{
    public class PersonalInfo
    {
        public Guid Id { get; set; }
        private string password;
        
        public string LoginID { get; set; }
        public string Password {
            get { return password; }
            set { 
                password = value;
                EncryptedPassword = EncryptDecrypt.Encrypt(value);
            }
        }

        public string Token { get; set; }

        public string EncryptedPassword { get; set; }

        public string MobileNumber { get; set; }
        public Sex Sex { get; set; }
        public DateTime Birthdate { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string EmailAddress1 { get; set; }
        public string EmailAddress2 { get; set; }
        public Address Address{ get; set; }

        public bool IsRequred()
        {
            if(LoginID != EmailAddress1)
            {
                throw new ArgumentNullException("LoginID and EmailAddress1 do not match.");
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
