using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stories.Data.Repositories;
using Stories.Data.Entities;
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
            var personGuid = Guid.NewGuid();
            var personalInfo = new Domain.Model.PersonalInfo(
              Guid.NewGuid(),
              personGuid,
              "aoyama@gmail.com",
              "aoyama@gmail.com"
            );
            personalInfo.EncryptedPassword = "password";
            personalInfo.Address = new Domain.Model.Address(Guid.NewGuid(), Domain.Model.CountryCode.Japan, "埼玉県", "所沢市");
            personalInfo.Birthdate = new DateTime(1971, 7, 28);
            personalInfo.EmailAddress2 = "aoyama2@gmail.com";
            personalInfo.MobileNumber = "09011223344";
            personalInfo.Sex = Sex.Female;

            
            User user = new User( personGuid,
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

