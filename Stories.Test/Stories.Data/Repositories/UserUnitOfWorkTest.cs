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
            User user = new User(Guid.Parse("ABC5DFFF-0109-4FCF-9512-41FF73BD24E7"),
                                    "FirstName",
                                    "LastName",
                                    Domain.Model.PersonType.User
                                    );

            user.MiddleName = "MiddleName";
            user.DisplayName = "F.L";
            user.LivingPlace = "TokyoCity";
            user.Occupation =
                "Engineer";

            PersonalInfo personalInfo = new PersonalInfo();
            user.PersonalInfo = personalInfo;
            personalInfo.Id = Guid.Parse("23BCE283-7D43-48ED-9F3E-319E0416DA89");
            personalInfo.Address = new Address();
            personalInfo.Birthdate = new DateTime(1971, 7, 28);
            personalInfo.Password = "abcde";
            personalInfo.EmailAddress1 = "aoyama@gmail.com";
            personalInfo.EmailAddress2 = "aoyama2@gmail.com";
            personalInfo.MobileNumber = "09011223344";
            personalInfo.Sex = Sex.Female;

            await userUnitOfWork.CreateUser(user);


            using (var context = new DatabaseContext())
            {
                GenericRepository<PersonEntity> personRepository = new GenericRepository<PersonEntity>(context);
                GenericRepository<PersonalInfoEntity> personalInfoRepository = new GenericRepository<PersonalInfoEntity>(context);
                var person = await personRepository.Get(user.Id);
                var personInfo = await personalInfoRepository.Get(personalInfo.Id);
                Assert.AreEqual(user.Id, person.Id);
                Assert.AreEqual(user.PersonType.ToString(), person.PersonType.ToString());
                Assert.AreEqual(user.FirstName, person.FirstName);
                Assert.AreEqual(personalInfo.Id, personInfo.Id);
                Assert.AreEqual("1l2y6OkawUI=", personalInfo.EncryptedPassword);

                await personRepository.Remove(person);
                await personalInfoRepository.Remove(personInfo);
            }         
        }       
    }
}

