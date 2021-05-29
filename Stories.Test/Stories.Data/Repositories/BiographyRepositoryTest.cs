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
                biography.Id = biography.Id;
                biography.Address = "GuizoMandaueCity";
                biography.Occupation = "Actress";
                biography.MaritalStatus = "Married";
                await biographyRepository.Add(biography);

                //Getting
                var getBiography = await biographyRepository.Get(biography.Id);

                Assert.AreEqual(getBiography.Id, biography.Id);
                Assert.AreEqual(getBiography.Address, biography.Address);
                Assert.AreEqual(getBiography.Occupation, biography.Occupation);
                Assert.AreEqual(getBiography.MaritalStatus, biography.MaritalStatus);

                //Upadating
                biography.Address = "MandaueCity";
                biography.Occupation = "engineer";
                await biographyRepository.Update(biography);
                var updatebiography = await biographyRepository.Get(biography.Id);
                Assert.AreEqual(updatebiography.Address, biography.Address);
                Assert.AreEqual(updatebiography.Occupation, biography.Occupation);

                ////Removing
                //await biographyRepository.Delete(biography);
                //var resultbiography = biographyRepository.Get(biography.Id).Result;
                //Assert.AreEqual(resultbiography, null);
            }
        }
             
    }
}
