using System;
using System.Collections.Generic;
using Stories.Utility;

namespace Stories.Domain.Model
{
    public class PersonalInfo
    {
        public PersonalInfo(Guid id, Guid personId, string loginId, string emailAddress1)
        {
            if( Guid.Empty == id)
            {
                throw new ArgumentException("id is a required field.");
            }
            if (Guid.Empty == personId)
            {
                throw new ArgumentException("personId is a required field.");
            }
            if (string.IsNullOrEmpty(loginId))
            {
                throw new ArgumentException("loginId is a required field.");
            }
            if (loginId != emailAddress1)
            {
                throw new ArgumentException("loginId and emailAddress1 do not match.");
            }
            
            this.Id = id;
            this.LoginID = loginId;
            this.PersonId = personId;
            this.EmailAddress1 = emailAddress1;
        }

        public Guid Id { get; set; }
        public string LoginID { get; set; }
        public Guid PersonId { get; set; }
        private string password;
        public string Password {
            get { return password; }
            set {
                password = value;
                EncryptedPassword = EncryptDecrypt.Encrypt(value);
            }
        }
        public string EmailAddress1 { get; set; }

        public string Token { get; set; }

        public string EncryptedPassword { get; set; }

        public string MobileNumber { get; set; }

        public Sex Sex { get; set; }
        
        public DateTime Birthdate { get; set; }
        
        public MaritalStatus MaritalStatus { get; set; }
      
        public string EmailAddress2 { get; set; }
     
        public Address Address{ get; set; }
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
