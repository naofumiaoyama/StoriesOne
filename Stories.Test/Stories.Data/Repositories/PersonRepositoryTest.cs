using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stories.Data;
using Stories.Data.Entities;
using Stories.Data.Repositories;



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
                // 1000000recoreds
                GenericRepository<Person> personRepository1 = new GenericRepository<Person>(context);
               
                //for (int i = 0; i < 1000000; i++)
                //{
                //    Person person1 = new Person();
                //    person1.Id = Guid.NewGuid();
                //    person1.PersonType = PersonType.User;
                //    person1.FirstName = "OtherFirst " + i.ToString();
                //    person1.MiddleName = "Makio";
                //    person1.LastName = "OtherLast";
                //    person1.DisplayName = "N.A";
                //    person1.SelfIntroduction = "私の自己紹介";
                //    person1.LivingPlace = "TokorozawaCity";
                //    person1.Occupation = "Engineer";
                //    await personRepository1.Add(person1);
                    
                //}
                
                
                // Adding
                GenericRepository<Person> personRepository = new GenericRepository<Person>(context);
                Person person = new Person();
                person.Id = Guid.Parse("B87DD83A-7F89-4AD0-BB4E-E94518F8A677");
                person.PersonType = PersonType.User;
                person.FirstName = "OtherFirst";
                person.MiddleName = "Makio";
                person.LastName = "OtherLast";
                person.DisplayName = "N.A";
                person.SelfIntroduction = "私の自己紹介";
                person.LivingPlace = "TokorozawaCity";
                person.Occupation = "Engineer";
                await personRepository.Add(person);


                // Getting
                var getPerson = await personRepository.Get(person.Id);

                Assert.AreEqual(getPerson.Id, person.Id);
                Assert.AreEqual(getPerson.PersonType, person.PersonType);
                Assert.AreEqual(getPerson.FirstName, person.FirstName);
                Assert.AreEqual(getPerson.LastName, person.LastName);
               
                Assert.AreEqual(getPerson.DisplayName, person.DisplayName);
                Assert.AreEqual(getPerson.SelfIntroduction, person.SelfIntroduction);
                Assert.AreEqual(getPerson.LivingPlace, person.LivingPlace);
                Assert.AreEqual(getPerson.Occupation, person.Occupation);


                // Updating
                person.FirstName = "Shigeyoshi";
                person.LastName = "Aoyama";
                await personRepository.Update(person);
                var updatePerson = await personRepository.Get(person.Id);
                Assert.AreEqual(updatePerson.FirstName, person.FirstName);
                Assert.AreEqual(updatePerson.LastName, person.LastName);

                // Removing
                await personRepository.Remove(person);
                var resultPerson = personRepository.Get(person.Id).Result;
                Assert.AreEqual(resultPerson, null);            
            }
        }
    }
}

