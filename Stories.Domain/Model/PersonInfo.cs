using System;
namespace Stories.Domain.Model
{
    public class PersonInfo
    {
        public Address Address { get; set; }
        public string MobileNumber { get; set; }
        public Sex Sex { get; set; }
        public DateTime Birthdate { get; set; }
        public string EmailAddress1 { get; set; }
        public string EmailAddress2 { get; set; }
    }

    public enum Sex
    {
        male,
        female,
    }
}
