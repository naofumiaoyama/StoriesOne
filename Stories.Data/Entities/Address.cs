using System;
using System.ComponentModel.DataAnnotations;


namespace Stories.Data.Entities
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }
        public Person Person { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Others { get; set; }
    }
}
