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
                PersonRepository personRepository = new PersonRepository(context);
                Person person = new Person();
                person.Id = Guid.Parse("");
                person.FirstName = "Naofumi";
                person.LastName = "Aoyama";
                person.LoginId = "naofumi.aoyoama@gmail.com";
                person.Password = "pass";
                person.DisplayName = "N.A";
                person.SelfIntroduction = "私の自己紹介";
                await personRepository.Add(person);

                // Getting
                var getPerson = await personRepository.Get(person.Id);

                Assert.AreEqual(getPerson.Id, person.Id);
                Assert.AreEqual(getPerson.FirstName, person.FirstName);
                Assert.AreEqual(getPerson.LastName, person.LastName);
                Assert.AreEqual(getPerson.LoginId, person.LoginId);
                Assert.AreEqual(getPerson.Password, person.Password);
                Assert.AreEqual(getPerson.DisplayName, person.DisplayName);
                Assert.AreEqual(getPerson.SelfIntroduction, person.SelfIntroduction);

                // Updating
                person.FirstName = "Jenalyn";
                person.LastName = "Albios";
                await personRepository.Update(person);
                var updatePerson = await personRepository.Get(person.Id);
                Assert.AreEqual(updatePerson.FirstName, person.FirstName);
                Assert.AreEqual(updatePerson.LastName, person.LastName);

                /// Removing
                await personRepository.Remove(person);
                var resultPerson = personRepository.Get(person.Id).Result;
                Assert.AreEqual(resultPerson, null);

            }
        }
    }
}

