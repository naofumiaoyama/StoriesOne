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
                GenericRepository<PersonalInfoEntity> personalInfoRepository = new GenericRepository<PersonalInfoEntity>(context);
                //adding
                PersonalInfoEntity personalInfo = new PersonalInfoEntity();
                personalInfo.Id = Guid.Parse("69da8943-2dbf-4c2b-842d-b328c704be29");
                personalInfo.PersonId = Guid.Parse("0389C8FF-2B0F-4215-8F47-DD58C69CA17C");
                personalInfo.LoginId = "chisumiAoyama@gmail.com";
                personalInfo.Password = "abcde";
                personalInfo.MobileNumber = "09011223344";
                personalInfo.Sex = SexEnum.Female;
                personalInfo.Birthdate = new DateTime(1995, 3, 27);
                personalInfo.EmailAddress1 = "Aoyama@gmail.com";
                personalInfo.EmailAddress2 = "Aoyama2@gmail.com";
                personalInfo.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                personalInfo.CreateDate = DateTime.Now;
                personalInfo.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                personalInfo.UpdateDate = DateTime.Now;
                await personalInfoRepository.Add(personalInfo);

                //Getting
                var getPersonalInfo = personalInfoRepository.Get(personalInfo.Id).Result;

                Assert.AreEqual(getPersonalInfo.PersonId, personalInfo.PersonId);
                Assert.AreEqual(getPersonalInfo.MobileNumber, personalInfo.MobileNumber);
                Assert.AreEqual(getPersonalInfo.Sex, personalInfo.Sex);
                Assert.AreEqual(getPersonalInfo.Birthdate, personalInfo.Birthdate);
                Assert.AreEqual(getPersonalInfo.EmailAddress1, personalInfo.EmailAddress1);

                //Updating
                personalInfo.MobileNumber = "09091068083";
                personalInfo.Sex = SexEnum.Male;
                personalInfo.Birthdate = new DateTime(1971, 7, 28);
                personalInfo.EmailAddress1 = "chisumi.aoyama@gmail.com";
                personalInfo.EmailAddress2 = "chisumi2@gmail.com";
                await personalInfoRepository.Update(personalInfo);
                var updatepersonalInfo = await personalInfoRepository.Get(personalInfo.Id);
                Assert.AreEqual(updatepersonalInfo.PersonId, personalInfo.PersonId);
                Assert.AreEqual(updatepersonalInfo.MobileNumber, personalInfo.MobileNumber);
                Assert.AreEqual(updatepersonalInfo.Sex, personalInfo.Sex);
                Assert.AreEqual(updatepersonalInfo.Birthdate, personalInfo.Birthdate);
                Assert.AreEqual(updatepersonalInfo.EmailAddress1, personalInfo.EmailAddress1);
                Assert.AreEqual(updatepersonalInfo.EmailAddress2, personalInfo.EmailAddress2);

                //Removing
                await personalInfoRepository.Remove(personalInfo);
                var resultpersonalInfo = personalInfoRepository.Get(personalInfo.PersonId).Result;
                Assert.AreEqual(resultpersonalInfo, null);
            }
        }

    }
}
