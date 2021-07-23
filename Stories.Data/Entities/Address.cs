using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Stories.Data.Entities
{
    public class Address : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("PersonalInfo")]
        public Guid PersonalInfoId { get; set; }
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
