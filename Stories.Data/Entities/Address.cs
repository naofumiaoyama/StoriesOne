using System;
using System.ComponentModel.DataAnnotations;


namespace Stories.Data.Entities
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }
        public Person Person { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string PrefectureCode { get; set; }
        public string PrefectureName { get; set; }
        public string StateCode { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string TownName { get; set; }
        public string Street { get; set; }
        public string Others { get; set; }
        public Guid CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
