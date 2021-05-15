using System.ComponentModel.DataAnnotations;


namespace Stories.Data.Entities
{
    public class User : Person
    {
        [Key]
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string UserIconURL { get; set; }
        public string SelfIntroduction { get; set; }
    }
}
