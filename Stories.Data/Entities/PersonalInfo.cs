using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Stories.Data.Entities
{
    public class PersonalInfo : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Person")]
        public Guid PersonId { get; set; }
        public string LoginId { get; set; }
        public string EncryptedPassword { get; set; }
        public string MobileNumber { get; set; }
        public SexEnum Sex { get; set; }
        public DateTime Birthdate { get; set; }
        public MaritalStatusEnum MaritalStatus { get; set; }
        public string EmailAddress1 { get; set; }
        public string EmailAddress2 { get; set; }
        public Guid AddressId { get; set; }

    }

    public enum SexEnum
    {
        Male = 1,
        Female = 2
    }
    public enum MaritalStatusEnum
    {
        Single = 1,
        Married = 2,
        Divorced = 3,
        Windowed = 4,
        Complicated = 5
    }
}

