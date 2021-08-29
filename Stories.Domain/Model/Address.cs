using System;
namespace Stories.Domain.Model
{
    public class Address
    {
        public Address(Guid id, 
                       string postalCode, 
                       CountryCode countryCode, 
                       string countryName, 
                       string prefectureName, 
                       string stateName, 
                       string cityName, 
                       string townName, 
                       string street,
                       string others)
        {
            if (Guid.Empty == id)
            {
                throw new ArgumentException("id is a required field.");
            }
            if (string.IsNullOrEmpty(postalCode))
            {
                throw new ArgumentException("postalcode is a required field");
            }
            if (!CountryCode.IsDefined(countryCode))
            {
                throw new ArgumentException("The countryCode has not been defined.");
            }
            if (string.IsNullOrEmpty(countryName))
            {
                throw new ArgumentException("countryName is required field");
            }
            if (string.IsNullOrEmpty(prefectureName))
            {
                throw new ArgumentException("prefectureName is a required field.");
            }
            if (string.IsNullOrEmpty(cityName))
            {
                throw new ArgumentException("cityName is a required field.");
            }
            if (string.IsNullOrEmpty(townName))
            {
                throw new ArgumentException("townName is a requierd field");
            }
            if (string.IsNullOrEmpty(street))
            {
                throw new ArgumentException("street is a required field");
            }
            if (string.IsNullOrEmpty(others))
            {
                throw new ArgumentException("others is a required field");
            }
            this.Id = id;
            this.PostalCode = postalCode;
            this.CountryCode = countryCode;
            this.CountryName = countryName;
            this.PrefectureName = prefectureName;
            this.StateName = stateName;
            this.CityName = cityName;
            this.TownName = townName;
            this.Street = street;
            this.Others = others;
        }
        public Guid Id { get; private set; }
        public string PostalCode { get; private set; }
        public CountryCode CountryCode { get; private set; }
        public string CountryName { get; private set; }
        public string PrefectureName { get; private set; }
        public string StateName { get; private set; }
        public string CityName { get; private set; }
        public string TownName { get; private set; }
        public string Street { get; private set; }
        public string Others { get; private set; }
    }

    public enum CountryCode
    {
        UnitedStates = 1,
        Japan = 81,
    }

}