using System;
using System.ComponentModel.DataAnnotations;


namespace Stories.Data.Entities
{
    public class PersonalInfo
    {
        [Key]
        public int Id { get; set; }
        public Person person { get; set; }
        public string MobileNumber { get; set; }
        public Sex Sex { get; set; }
        public DateTime Birthdate { get; set; }
        public string EmailAddress {get; set;}

    }

    public enum Sex
    {
        Male = 1,
        Female = 2
    }
}

