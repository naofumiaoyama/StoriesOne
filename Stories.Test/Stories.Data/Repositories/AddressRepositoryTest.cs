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
                GenericRepository<Address> addressRepository = new GenericRepository<Address>(context);
                Address address = new Address();
                address.Id = Guid.Parse("52E91D81-D193-4BDC-911A-63C7F7CC099F");
                address.CountryCode = CountryCode.Japan;
                address.CountryName = "Japan";
                address.PrefectureName = "SaitamaPrefecture";
                address.StateName = "Saitama";
                address.CityName = "TorokorozawaCity";
                address.TownName = "Tokorozawa";
                address.Street = "Kotesashi";
                address.Others = "etc";
                await addressRepository.Add(address);

                //Getting
                var getAddress = await addressRepository.Get(address.Id);

                Assert.AreEqual(getAddress.Id, address.Id);
                Assert.AreEqual(getAddress.CountryCode, address.CountryCode);
                Assert.AreEqual(getAddress.CountryName, address.CountryName);
                Assert.AreEqual(getAddress.PrefectureName, address.PrefectureName);
                Assert.AreEqual(getAddress.StateName, address.StateName);
                Assert.AreEqual(getAddress.CityName, address.CityName);
                Assert.AreEqual(getAddress.TownName, address.TownName);
                Assert.AreEqual(getAddress.Street, address.Street);
                Assert.AreEqual(getAddress.Others, address.Others);

                //Updating
                address.CountryCode = CountryCode.UnitedStates;
                address.CountryName = "United States";
                address.PrefectureName = "Havana";
                address.StateName = "SouthCarolina";
                address.CityName = "NewYork";
                address.TownName = "regatta";
                address.Street = "24Cornwellwest";
                address.Others = "more";
                await addressRepository.Update(address);
                var updateaddress = await addressRepository.Get(address.Id);
                Assert.AreEqual(updateaddress.CountryCode, address.CountryCode);
                Assert.AreEqual(updateaddress.CountryName, address.CountryName);
                Assert.AreEqual(updateaddress.PrefectureName, address.PrefectureName);
                Assert.AreEqual(updateaddress.CityName, address.CityName);
                Assert.AreEqual(updateaddress.TownName, address.TownName);
                Assert.AreEqual(updateaddress.Street, address.Street);

                //removing
                await addressRepository.Remove(address);
                var resultaddress = addressRepository.Get(address.Id).Result;
                Assert.AreEqual(resultaddress, null);

            }
        }

  }
}
