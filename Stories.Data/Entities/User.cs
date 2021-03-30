using System.ComponentModel.DataAnnotations;


namespace Stories.Data.Entities
{
    public class User
    {
        [Key]
        public string Login_Id { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
    }
}
