using System;
namespace Stories.Domain.Model
{
    public class Address
    {
        public Address(Guid id, CountryCode countryCode, string prefectureName, string cityName )
        {
            if (Guid.Empty == id)
            {
                throw new ArgumentException("id is a required field.");
            }
            if (!CountryCode.IsDefined(countryCode))
            {
                throw new ArgumentException("The countryCode has not been defined.");
            }
            if (string.IsNullOrEmpty(prefectureName))
            {
                throw new ArgumentException("prefectureName is a required field.");
            }
            if (string.IsNullOrEmpty(cityName))
            {
                throw new ArgumentException("cityName is a required field.");
            }
            
            this.Id = id;
            this.CountryCode = countryCode;
            this.PrefectureName = prefectureName;
            this.CityName = cityName;
        }
        public Guid Id { get; private set; }
        public string PostalCode { get; set; }
        public CountryCode CountryCode { get; private set; }
        public string CountryName { get; set; }
        public string PrefectureName { get; private set; }
        public string StateName { get; set; }
        public string CityName { get; private set; }
        public string TownName { get; set; }
        public string Street { get; set; }
        public string Others { get; set; }
    }

    public enum CountryCode
    {
        UnitedStates = 1,
        Japan = 81,
    }

}