using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stories.Data.Repositories;
using Stories.Data;
using Stories.Domain.Model;

namespace Stories.Test.Stories.Data.Repositories
{
    [TestClass]
    public class UserUnitOfWorkTest
    {
        [TestMethod]
        public async Task CreateUserTest()
        {
            UserUnitOfWork userUnitOfWork = new UserUnitOfWork();
            var personId = Guid.NewGuid();
            var personalInfo = new PersonalInfo(
              Guid.NewGuid(),
              personId,
              "aoyama@gmail.com",
              "password",
              "",
              "09091120212",
              new DateTime(1971,7,28),
              Sex.Male,
              MaritalStatus.Married,
              "aoyama@gmail.com",
              "aoyama2@gmail.com",
              new Address(Guid.NewGuid(), "3451124", CountryCode.Japan, "日本", "埼玉県", "", "所沢市","小手指町", "2-2-2", "シャルル111")
            ); 
            
            User user = new User(personId,
                                 "FirstName",
                                 "LastName",
                                 "NickName",
                                 personalInfo,
                                 Domain.Model.PersonType.User,
                                 "F.L",
                                 "SelfIntroduction",
                                 "LivingPlace",
                                 "Engineer",
                                 null,null,null
                                 );

            await userUnitOfWork.CreateUser(user);


            using (var context = new DatabaseContext())
            {
                GenericRepository<global::Stories.Data.Entities.Person> personRepository = new GenericRepository<global::Stories.Data.Entities.Person>(context);
                GenericRepository<global::Stories.Data.Entities.PersonalInfo> personalInfoRepository = new GenericRepository<global::Stories.Data.Entities.PersonalInfo>(context);
                var person = await personRepository.Get(user.Id);
                var personInfo = await personalInfoRepository.Get(personalInfo.Id);
                Assert.AreEqual(user.Id, person.Id);
                Assert.AreEqual(user.PersonType.ToString(), person.PersonType.ToString());
                Assert.AreEqual(user.FirstName, person.FirstName);
                Assert.AreEqual(personalInfo.Id, personInfo.Id);
                Assert.AreEqual("password", personalInfo.EncryptedPassword);

                await personRepository.Remove(person);
            }         
        }       
    }
}

