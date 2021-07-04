﻿using Stories.Data.Entities;
using Stories.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.InitialData
{
   public class AddressData
    {
        public async Task MakeData()
        {
            using (var context = new DatabaseContext())
            {
                AddressRepository addressRepository = new AddressRepository(context);
                Address address = new Address();
                address.Id = Guid.Parse("4487058C-0C80-4655-8FC6-DFDA0B1B1563");
                address.PersonId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                address.CountryCode = "81";
                address.CountryName = "Japan";
                address.PrefectureCode = "301";
                address.PrefectureName = "SaitamaPrefecture";
                address.StateCode = "23";
                address.StateName = "Saitama";
                address.CityName = "TorokorozawaCity";
                address.TownName = "Tokorozawa";
                address.Street = "Kotesashi";
                address.Others = "etc";
                address.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                address.CreateDate = DateTime.Now;
                address.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                address.UpdateDate = DateTime.Now;
                await addressRepository.Add(address);


                Address address2 = new Address();
                address2.Id = Guid.Parse("2B3CD24F-5802-4D74-BACD-5DE67A2B2FCB");
                address2.PersonId = Guid.Parse("63020A23-8B13-4381-A4E6-C71A2609170D");
                address2.CountryCode = "1";
                address2.CountryName = "UnitedStates";
                address2.PrefectureCode = "91";
                address2.PrefectureName = "Havana";
                address2.StateCode = "43";
                address2.StateName = "SouthCarolina";
                address2.CityName = "NewYork";
                address2.TownName = "regatta";
                address2.Street = "24Cornwellwest";
                address2.Others = "more";
                address2.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                address2.CreateDate = DateTime.Now;
                address2.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                address2.UpdateDate = DateTime.Now;
                await addressRepository.Add(address2);
            }
        }

        public async Task DeleteData()
        {
            using (var context = new DatabaseContext())
            {
                AddressRepository addressRepository = new AddressRepository(context);
                var address1 = addressRepository.Get(Guid.Parse("4487058C-0C80-4655-8FC6-DFDA0B1B1563")).Result;
                if (address1 != null) { await addressRepository.Remove(address1); }

                var address2 = addressRepository.Get(Guid.Parse("2B3CD24F-5802-4D74-BACD-5DE67A2B2FCB")).Result;
                if (address2 != null) { await addressRepository.Remove(address2); }
            }
        }
   }
}