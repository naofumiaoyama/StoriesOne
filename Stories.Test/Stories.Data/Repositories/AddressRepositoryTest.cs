using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stories.Data;
using Stories.Data.Entities;
using Stories.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace Stories.Test.Stories.Data.Repositories
{
    [TestClass]
  public  class AddressRepositoryTest
  {
        [TestMethod]
       public async Task CRUDTest()
       {
            using (var context = new DatabaseContext())
            {
                //adding
                AddressRepository addressRepository = new AddressRepository(context);
                Address address = new Address();
                address.Id = Guid.Parse("52E91D81-D193-4BDC-911A-63C7F7CC099F");
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
                await addressRepository.Add(address);

                //Getting
                var getAddress = await addressRepository.Get(address.Id);

                Assert.AreEqual(getAddress.Id, address.Id);
                Assert.AreEqual(getAddress.PersonId, address.PersonId);
                Assert.AreEqual(getAddress.CountryCode, address.CountryCode);
                Assert.AreEqual(getAddress.CountryName, address.CountryName);
                Assert.AreEqual(getAddress.PrefectureCode, address.PrefectureCode);
                Assert.AreEqual(getAddress.PrefectureName, address.PrefectureName);
                Assert.AreEqual(getAddress.StateCode, address.StateCode);
                Assert.AreEqual(getAddress.StateName, address.StateName);
                Assert.AreEqual(getAddress.CityName, address.CityName);
                Assert.AreEqual(getAddress.TownName, address.TownName);
                Assert.AreEqual(getAddress.Street, address.Street);
                Assert.AreEqual(getAddress.Others, address.Others);

                //Updating
                address.CountryCode = "1";
                address.CountryName = "United States";
                address.PrefectureCode = "91";
                address.PrefectureName = "Havana";
                address.StateCode = "43";
                address.StateName = "SouthCarolina";
                address.CityName = "NewYork";
                address.TownName = "regatta";
                address.Street = "24Cornwellwest";
                address.Others = "more";
                await addressRepository.Update(address);
                var updateAddress = await addressRepository.Get(address.Id);
                Assert.AreEqual(updateAddress.CountryCode, address.CountryCode);
                Assert.AreEqual(updateAddress.CountryName, address.CountryName);
                Assert.AreEqual(updateAddress.PrefectureCode, address.PrefectureCode);
                Assert.AreEqual(updateAddress.PrefectureName, address.PrefectureName);
                Assert.AreEqual(updateAddress.StateCode, address.StateCode);
                Assert.AreEqual(updateAddress.CityName, address.CityName);
                Assert.AreEqual(updateAddress.TownName, address.TownName);
                Assert.AreEqual(updateAddress.Street, address.Street);

                //removing
                await addressRepository.Remove(address);
                var resultaddress = addressRepository.Get(address.Id).Result;
                Assert.AreEqual(resultaddress, null);

            }
        }

  }
}
