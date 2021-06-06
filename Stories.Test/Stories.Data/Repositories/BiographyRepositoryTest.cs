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
  public  class BiographyRepositoryTest
    {
        [TestMethod]
        public async Task CrudTest()
        {
            using (var context = new DatabaseContext())
            {
                //adding
                BiographyRepository biographyRepository = new BiographyRepository(context);
                Biography biography = new Biography();
                biography.Id = Guid.NewGuid();
                biography.Person = new Person();
                biography.LivingPlace = "Guizo";
                biography.Occupation = "Actress";
                biography.MaritalStatus = MaritalStatus.Single;
                await biographyRepository.Add(biography);

                //Getting
                var getBiography = biographyRepository.Get(biography.Id).Result;
                Assert.AreEqual(getBiography.Id, biography.Id);
                Assert.AreEqual(getBiography.LivingPlace, biography.LivingPlace);
                Assert.AreEqual(getBiography.Occupation, biography.Occupation);
                Assert.AreEqual(getBiography.MaritalStatus, biography.MaritalStatus);

                //Updating
                biography.LivingPlace = "MandaueCity";
                biography.Occupation = "engineer";
                await biographyRepository.Update(biography);
                var updatebiography = await biographyRepository.Get(biography.Id);
                Assert.AreEqual(updatebiography.LivingPlace, biography.LivingPlace);
                Assert.AreEqual(updatebiography.Occupation, biography.Occupation);
                Assert.AreEqual(updatebiography.MaritalStatus, biography.MaritalStatus);

                //Removing
                await biographyRepository.Delete(biography);
                var resultbiography = biographyRepository.Get(biography.Id).Result;
                Assert.AreEqual(resultbiography, null);
            }
        }
             
    }
}
