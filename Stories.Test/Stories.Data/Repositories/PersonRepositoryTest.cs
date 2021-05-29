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
                person.Id = Guid.NewGuid();
                person.GivenName = "Naofumi";
                person.FamilyName = "Aoyama";
                person.LoginId = "naofumi.aoyoama@gmail.com";
                person.Password = "pass";
                person.DisplayName = "N.A";
                person.UserIconURL = "https://www.test.co.jp/test.jpg";
                person.SelfIntroduction = "私の自己紹介";
                await personRepository.Add(person);

                // Getting
                var getPerson = await personRepository.Get(person.Id);

                Assert.AreEqual(getPerson.Id, person.Id);
                Assert.AreEqual(getPerson.GivenName, person.GivenName);
                Assert.AreEqual(getPerson.FamilyName, person.FamilyName);
                Assert.AreEqual(getPerson.LoginId, person.LoginId);
                Assert.AreEqual(getPerson.Password, person.Password);
                Assert.AreEqual(getPerson.DisplayName, person.DisplayName);
                Assert.AreEqual(getPerson.UserIconURL, person.UserIconURL);
                Assert.AreEqual(getPerson.SelfIntroduction, person.SelfIntroduction);

                // Updating
                person.GivenName = "Jenalyn";
                person.FamilyName = "Albios";
                await personRepository.Update(person);
                var updatePerson = await personRepository.Get(person.Id);
                Assert.AreEqual(updatePerson.FamilyName, person.FamilyName);
                Assert.AreEqual(updatePerson.GivenName, person.GivenName);

                //// Removing
                //await personRepository.Remove(person);
                //var resultPerson = personRepository.Get(person.Id).Result;
                //Assert.AreEqual(resultPerson, null);

            }
        }
    }
}

