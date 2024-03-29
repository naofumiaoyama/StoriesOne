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
                GenericRepository<Address>addressRepository = new GenericRepository<Address>(context);
                Address address = new Address();
                address.Id = Guid.Parse("21eb3545-604e-42b4-9c7f-7057e55e2045");
                address.PostalCode = "3451111";
                address.CountryCode = CountryCode.Japan;
                address.CountryName = "Japan";
                address.PrefectureName = "SaitamaPrefecture";
                address.StateName = "Saitama";
                address.CityName = "TorokorozawaCity";
                address.TownName = "Tokorozawa";
                address.Street = "";
                address.Others = "etc";
                address.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                address.CreateDate = DateTime.Now;
                address.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                address.UpdateDate = DateTime.Now;
                await addressRepository.Add(address);

                Address address2 = new Address();
                address2.Id = Guid.Parse("2B3CD24F-5802-4D74-BACD-5DE67A2B2FCB");
                address2.PostalCode = "3441113";
                address2.CountryCode = CountryCode.Japan;
                address2.CountryName = "UnitedStates";
                address2.PrefectureName = "Havana";
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

                Address address3 = new Address();
                address3.Id = Guid.Parse("7e4a36cb-4840-41f3-b14e-a283b5881621");
                address3.PostalCode = "3441113";
                address3.CountryCode = CountryCode.Japan;
                address3.CountryName = "Japan";
                address3.PrefectureName = "TokyoPrefecture";
                address3.StateName = "Tokyo";
                address3.CityName = "ToshimaCity";
                address3.TownName = "Toshima";
                address3.Street = "";
                address3.Others = "etc";
                address3.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                address3.CreateDate = DateTime.Now;
                address3.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                address3.UpdateDate = DateTime.Now;
                await addressRepository.Add(address3);//


            }
        }

        public async Task DeleteData()
        {
            using (var context = new DatabaseContext())
            {
                GenericRepository<Address> addressRepository = new GenericRepository<Address>(context);
                var address1 = addressRepository.Get(Guid.Parse("21eb3545-604e-42b4-9c7f-7057e55e2045")).Result;
                if (address1 != null) { await addressRepository.Remove(address1); }

                var address2 = addressRepository.Get(Guid.Parse("2B3CD24F-5802-4D74-BACD-5DE67A2B2FCB")).Result;
                if (address2 != null) { await addressRepository.Remove(address2); }

                var address3 = addressRepository.Get(Guid.Parse("7e4a36cb-4840-41f3-b14e-a283b5881621")).Result;
                if (address3 != null) { await addressRepository.Remove(address3); }
            }
        }
   }
}
