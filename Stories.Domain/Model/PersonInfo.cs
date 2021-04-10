using System;
namespace Stories.Domain.Model
{
    public class PersonInfo
    {
        // 個人情報
        public Address Address { get; set; }
        public string MobileNumber { get; set; }
        public Sex Sex { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
    }

    public enum Sex
    {
        male,
        female,
    }
}
