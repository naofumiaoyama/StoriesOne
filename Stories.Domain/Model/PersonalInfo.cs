using System;
using System.Collections.Generic;
using Stories.Utility;

namespace Stories.Domain.Model
{
    public class PersonalInfo
    {
        public PersonalInfo(Guid id, 
                            Guid personId, 
                            string loginId, 
                            string encryptedPassword, 
                            string token, 
                            string mobileNumber,
                            DateTime birthDate, 
                            Sex sex, 
                            MaritalStatus maritalStatus, 
                            string emailAddress1, 
                            string emailAddress2, 
                            Address address)
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
            if(!Sex.IsDefined(Sex))
            {
                throw new ArgumentException("The sex has not been define");
            }
            if(!MaritalStatus.IsDefined(MaritalStatus))
            {
                throw new ArgumentException("The maritalStatus has not been define");
            }
            if (loginId != emailAddress1)
            {
                throw new ArgumentException("loginId and emailAddress1 do not match.");
            }
            if(string.IsNullOrEmpty(Token))
            {
                throw new ArgumentException("token is a required field");
            }
            if(string.IsNullOrEmpty(EmailAddress2))
            {
                throw new ArgumentException("loginId and emailAddress2 do not match");
            }
            
            
            this.Id = id;
            this.LoginID = loginId;
            this.EncryptedPassword = encryptedPassword;
            this.Token = token;
            this.MobileNumber = mobileNumber;
            this.PersonId = personId;
            this.Sex = sex;
            this.Birthdate= birthDate;
            this.MaritalStatus = maritalStatus;
            this.EmailAddress1 = emailAddress1;
            this.EmailAddress2 = emailAddress2;
            this.Address = address;
        }

        public Guid Id { get; private set; }

        public Guid PersonId { get; private set; }

        public string LoginID { get; private set; }

        public string EncryptedPassword { get; private set; }

        public string Token { get; private set; }

        public string MobileNumber { get; private set; }

        public Sex Sex { get; private set; }
        
        public DateTime Birthdate { get; private set; }
        
        public MaritalStatus MaritalStatus { get; private set; }

        public string EmailAddress1 { get; private set; }

        public string EmailAddress2 { get; private set; }
     
        public Address Address{ get; private set; }
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
