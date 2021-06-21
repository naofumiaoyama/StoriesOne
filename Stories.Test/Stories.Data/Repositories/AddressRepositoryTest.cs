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
                address.Id = Guid.Parse("4487058C-0C80-4655-8FC6-DFDA0B1B1563");
                address.PersonId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                address.CountryCode = "81";
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
                address.CountryCode = "1";
                address.CountryName = "United States";
                address.CityName = "NewYork";
                await addressRepository.Update(address);
                var updateAddress = await addressRepository.Get(address.Id);
                Assert.AreEqual(updateAddress.CountryName, address.CountryName);
                Assert.AreEqual(updateAddress.CityName, address.CityName);

                //Removing
                await addressRepository.Remove(address);
                var resultaddress = addressRepository.Get(address.Id).Result;
                Assert.AreEqual(resultaddress, null);

            }
        }

  }
}
