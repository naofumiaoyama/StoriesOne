using System;
using System.ComponentModel.DataAnnotations;

namespace Stories.Data.Entities
{
    public class Person
    {
        [Key]
        public Guid Id {get; set;}
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public PersonType PersonType { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string SelfIntroduction { get; set; }
        public string LivingPlace { get; set; }
        public string Occupation { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public Guid CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
    public enum PersonType
    {
        User = 1,
        SystemOperater = 2,
        Administrator = 3
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
