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
    public class PersonRepositoryTest
    {
        [TestMethod]
        public async Task CRUDTest()
        {
            using (var context = new DatabaseContext())
            {
                // Adding
                GenericRepository<PersonEntity> personRepository = new GenericRepository<PersonEntity>(context);
                PersonEntity personEntity = new PersonEntity();
                personEntity.Id = Guid.Parse("B87DD83A-7F89-4AD0-BB4E-E94518F8A677");
                personEntity.PersonType = PersonType.User;
                personEntity.FirstName = "OtherFirst";
                personEntity.MiddleName = "Makio";
                personEntity.LastName = "OtherLast";
                personEntity.DisplayName = "N.A";
                personEntity.SelfIntroduction = "私の自己紹介";
                personEntity.LivingPlace = "TokorozawaCity";
                personEntity.Occupation = "Engineer";
                await personRepository.Add(personEntity);


                // Getting
                var getPerson = await personRepository.Get(personEntity.Id);

                Assert.AreEqual(getPerson.Id, personEntity.Id);
                Assert.AreEqual(getPerson.PersonType, personEntity.PersonType);
                Assert.AreEqual(getPerson.FirstName, personEntity.FirstName);
                Assert.AreEqual(getPerson.LastName, personEntity.LastName);
               
                Assert.AreEqual(getPerson.DisplayName, personEntity.DisplayName);
                Assert.AreEqual(getPerson.SelfIntroduction, personEntity.SelfIntroduction);
                Assert.AreEqual(getPerson.LivingPlace, personEntity.LivingPlace);
                Assert.AreEqual(getPerson.Occupation, personEntity.Occupation);


                // Updating
                personEntity.FirstName = "Shigeyoshi";
                personEntity.LastName = "Aoyama";
                await personRepository.Update(personEntity);
                var updatePerson = await personRepository.Get(personEntity.Id);
                Assert.AreEqual(updatePerson.FirstName, personEntity.FirstName);
                Assert.AreEqual(updatePerson.LastName, personEntity.LastName);

                // Removing
                await personRepository.Remove(personEntity);
                var resultPerson = personRepository.Get(personEntity.Id).Result;
                Assert.AreEqual(resultPerson, null);            
            }
        }
    }
}

