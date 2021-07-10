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
  public  class addressEntityRepositoryTest
  {
        [TestMethod]
       public async Task CRUDTest()
       {
            using (var context = new DatabaseContext())
            {
                //adding
                GenericRepository<AddressEntity> addressEntityRepository = new GenericRepository<AddressEntity>(context);
                AddressEntity addressEntity = new AddressEntity();
                addressEntity.Id = Guid.Parse("52E91D81-D193-4BDC-911A-63C7F7CC099F");
                addressEntity.PersonId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                addressEntity.CountryCode = "81";
                addressEntity.CountryName = "Japan";
                addressEntity.PrefectureCode = "301";
                addressEntity.PrefectureName = "SaitamaPrefecture";
                addressEntity.StateCode = "23";
                addressEntity.StateName = "Saitama";
                addressEntity.CityName = "TorokorozawaCity";
                addressEntity.TownName = "Tokorozawa";
                addressEntity.Street = "Kotesashi";
                addressEntity.Others = "etc";
                await addressEntityRepository.Add(addressEntity);

                //Getting
                var getAddressEntity = await addressEntityRepository.Get(addressEntity.Id);

                Assert.AreEqual(getAddressEntity.Id, addressEntity.Id);
                Assert.AreEqual(getAddressEntity.PersonId, addressEntity.PersonId);
                Assert.AreEqual(getAddressEntity.CountryCode, addressEntity.CountryCode);
                Assert.AreEqual(getAddressEntity.CountryName, addressEntity.CountryName);
                Assert.AreEqual(getAddressEntity.PrefectureCode, addressEntity.PrefectureCode);
                Assert.AreEqual(getAddressEntity.PrefectureName, addressEntity.PrefectureName);
                Assert.AreEqual(getAddressEntity.StateCode, addressEntity.StateCode);
                Assert.AreEqual(getAddressEntity.StateName, addressEntity.StateName);
                Assert.AreEqual(getAddressEntity.CityName, addressEntity.CityName);
                Assert.AreEqual(getAddressEntity.TownName, addressEntity.TownName);
                Assert.AreEqual(getAddressEntity.Street, addressEntity.Street);
                Assert.AreEqual(getAddressEntity.Others, addressEntity.Others);

                //Updating
                addressEntity.CountryCode = "1";
                addressEntity.CountryName = "United States";
                addressEntity.PrefectureCode = "91";
                addressEntity.PrefectureName = "Havana";
                addressEntity.StateCode = "43";
                addressEntity.StateName = "SouthCarolina";
                addressEntity.CityName = "NewYork";
                addressEntity.TownName = "regatta";
                addressEntity.Street = "24Cornwellwest";
                addressEntity.Others = "more";
                await addressEntityRepository.Update(addressEntity);
                var updateaddressEntity = await addressEntityRepository.Get(addressEntity.Id);
                Assert.AreEqual(updateaddressEntity.CountryCode, addressEntity.CountryCode);
                Assert.AreEqual(updateaddressEntity.CountryName, addressEntity.CountryName);
                Assert.AreEqual(updateaddressEntity.PrefectureCode, addressEntity.PrefectureCode);
                Assert.AreEqual(updateaddressEntity.PrefectureName, addressEntity.PrefectureName);
                Assert.AreEqual(updateaddressEntity.StateCode, addressEntity.StateCode);
                Assert.AreEqual(updateaddressEntity.CityName, addressEntity.CityName);
                Assert.AreEqual(updateaddressEntity.TownName, addressEntity.TownName);
                Assert.AreEqual(updateaddressEntity.Street, addressEntity.Street);

                //removing
                await addressEntityRepository.Remove(addressEntity);
                var resultaddressEntity = addressEntityRepository.Get(addressEntity.Id).Result;
                Assert.AreEqual(resultaddressEntity, null);

            }
        }

  }
}
