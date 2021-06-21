using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Stories.Data.Entities
{
    public class PersonalInfo : BaseEntity
    {
        [Key]
        [ForeignKey("Person")]
        public Guid PersonId { get; set; }
        public string MobileNumber { get; set; }
        public Sex Sex { get; set; }
        public DateTime Birthdate { get; set; }
        public string EmailAddress1 {get; set;}
        public string EmailAddress2 { get; set; }
 
    }

    public enum Sex
    {
        Male = 1,
        Female = 2
    }
}

