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
   public class PersonalInfoRepositoryTest
    {
        [TestMethod]
        public async Task CRUDTest()
        {
            using (var context = new DatabaseContext())
            {
                //adding
                PersonalInfoRepository personalInfoRepository = new PersonalInfoRepository(context);
                PersonalInfo personalInfo = new PersonalInfo();

                personalInfo.Person = new Person();
                personalInfo.MobileNumber = "09260018922";
                personalInfo.Sex = Sex.Female;
                personalInfo.Birthdate = new DateTime(1995, 2, 27);
                personalInfo.EmailAddress = "albiosjenalyn27@gmail.com";
                await personalInfoRepository.Add(personalInfo);

                //Getting
                var getPersonalInfo = personalInfoRepository.Get(personalInfo.Id).Result;

                Assert.AreEqual(getPersonalInfo.Id, personalInfo.Id);
                Assert.AreEqual(getPersonalInfo.Person, personalInfo.Person);
                Assert.AreEqual(getPersonalInfo.MobileNumber, personalInfo.MobileNumber);
                Assert.AreEqual(getPersonalInfo.Sex, personalInfo.Sex);
                Assert.AreEqual(getPersonalInfo.Birthdate, personalInfo.Birthdate);
                Assert.AreEqual(getPersonalInfo.EmailAddress, personalInfo.EmailAddress);

                //Updating
                personalInfo.Person = new Person();
                personalInfo.MobileNumber = "09091068083";
                personalInfo.Sex = Sex.Male;
                personalInfo.Birthdate = new DateTime(1971, 7, 28);
                personalInfo.EmailAddress = "naofumi.aoyama@gmail.com";
                await personalInfoRepository.Update(personalInfo);
                var updatePersonalInfo = await personalInfoRepository.Get(personalInfo.Id);
                Assert.AreEqual(updatePersonalInfo.Person, personalInfo.Person);
                Assert.AreEqual(updatePersonalInfo.MobileNumber, personalInfo.MobileNumber);
                Assert.AreEqual(updatePersonalInfo.Sex, personalInfo.Sex);
                Assert.AreEqual(updatePersonalInfo.Birthdate, personalInfo.Birthdate);
                Assert.AreEqual(updatePersonalInfo.EmailAddress, personalInfo.EmailAddress);

                ////Removing
                await personalInfoRepository.Delete(personalInfo);
                var resultPersonalInfo = personalInfoRepository.Get(personalInfo.Id).Result;
                Assert.AreEqual(resultPersonalInfo, null);
            }
        }

    }
}
