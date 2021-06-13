using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stories.Data;
using Stories.Data.Entities;
using Stories.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                address.Id = Guid.NewGuid();
                address.Person = new Person();
                address.CountryName = "Japan";
                address.CityName = "TorokorozawaCityName";
                address.Street = "Kotesashi";
                address.Others = "etc";
                await addressRepository.Add(address);

                //Getting
                var getAddress = await addressRepository.Get(address.Id);

                Assert.AreEqual(getAddress.Id, address.Id);
                Assert.AreEqual(getAddress.CountryName, address.CountryName);
                Assert.AreEqual(getAddress.CityName, address.CityName);
                Assert.AreEqual(getAddress.Street, address.Street);
                Assert.AreEqual(getAddress.Others, address.Others);

                //Updating
                address.CountryName = "Japan";
                address.CityName = "TokorozawaCityName";
                await addressRepository.Update(address);
                var updateAddress = await addressRepository.Get(address.Id);
                Assert.AreEqual(updateAddress.CountryName, address.CountryName);
                Assert.AreEqual(updateAddress.CityName, address.CityName);

                ////Removing
                await addressRepository.Remove(address);
                var resultaddress = addressRepository.Get(address.Id).Result;
                Assert.AreEqual(resultaddress, null);

            }
        }

  }
}
