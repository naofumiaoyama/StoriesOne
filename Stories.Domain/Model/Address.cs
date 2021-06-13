using System;
namespace Stories.Domain.Model
{
    public class Address
    {
        public Guid Id { get; set; }
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
    }
}

public enum CountryCode
{
    UnitedStates = 1,
    Japan = 81,

}