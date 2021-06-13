using System;
using System.ComponentModel.DataAnnotations;


namespace Stories.Data.Entities
{
    public class PersonalInfo
    {
        [Key]
        public Guid PersonId { get; set; }
        public string MobileNumber { get; set; }
        public Sex Sex { get; set; }
        public DateTime Birthdate { get; set; }
        public string EmailAddress1 {get; set;}
        public string EmailAddress2 { get; set; }
        public Guid CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
    }

    public enum Sex
    {
        Male = 1,
        Female = 2
    }
}

