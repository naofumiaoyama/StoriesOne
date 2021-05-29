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
                
                personalInfo.person = await new PersonRepository(context).Get(Guid.Parse("0E407699-EDE4-4C2B-8699-2DA8F2BD75E2"));
                personalInfo.MobileNumber = "09260018922";
                personalInfo.Sex = Sex.Female;
                personalInfo.Birthdate = new DateTime(1995, 2, 27);
                personalInfo.EmailAddress = "albiosjenalyn27@gmail.com";
                await personalInfoRepository.Add(personalInfo);

                //Getting
                var getPersonalInfo = personalInfoRepository.Get(personalInfo.Id).Result;

                Assert.AreEqual(getPersonalInfo.Id, personalInfo.Id);
                Assert.AreEqual(getPersonalInfo.person, personalInfo.person);
                Assert.AreEqual(getPersonalInfo.MobileNumber, personalInfo.MobileNumber);
                Assert.AreEqual(getPersonalInfo.Sex, personalInfo.Sex);
                Assert.AreEqual(getPersonalInfo.Birthdate, personalInfo.Birthdate);
                Assert.AreEqual(getPersonalInfo.EmailAddress, personalInfo.EmailAddress);

                //Updating
                personalInfo.person = await new PersonRepository(context).Get(Guid.Parse("06d6a30f-04dc-4868-a90a-15613da26891"));
                personalInfo.MobileNumber = "09091068083";
                personalInfo.Sex = Sex.Male;
                personalInfo.Birthdate = new DateTime(1971, 7, 28);
                personalInfo.EmailAddress = "naofumi.aoyama@gmail.com";
                await personalInfoRepository.Update(personalInfo);
                var updatePersonalInfo = await personalInfoRepository.Get(personalInfo.Id);
                Assert.AreEqual(updatePersonalInfo.person, personalInfo.person);
                Assert.AreEqual(updatePersonalInfo.MobileNumber, personalInfo.MobileNumber);
                Assert.AreEqual(updatePersonalInfo.Sex, personalInfo.Sex);
                Assert.AreEqual(updatePersonalInfo.Birthdate, personalInfo.Birthdate);
                Assert.AreEqual(updatePersonalInfo.EmailAddress, personalInfo.EmailAddress);


                //Removing
                await personalInfoRepository.Delete(personalInfo);
                var resultPersonalInfo = personalInfoRepository.Get(personalInfo.Id).Result;
                Assert.AreEqual(resultPersonalInfo, null);
            }
        }

    }
}
