using System;
namespace Stories.Api.Model
{
    public class PersonInfo
    {
        public string MobileNumber { get; set; }
        public Sex Sex { get; set; }
        public PurposeOfAccount PurposeOfAccount { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
    }
    public enum Sex
    {
        male,
        female,
    }
    public enum PurposeOfAccount
    {
        Private,
        Business,
    }
}
