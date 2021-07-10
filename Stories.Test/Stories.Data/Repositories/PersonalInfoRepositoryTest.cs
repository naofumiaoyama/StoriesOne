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
   public class personalInfoEntityRepositoryTest
    {
        [TestMethod]
        public async Task CRUDTest()
        {
            using (var context = new DatabaseContext())
            {
                GenericRepository<PersonalInfoEntity> personalInfoEntityRepository = new GenericRepository<PersonalInfoEntity>(context);
                //adding
                PersonalInfoEntity personalInfoEntity = new PersonalInfoEntity();
                personalInfoEntity.PersonId = Guid.Parse("0389C8FF-2B0F-4215-8F47-DD58C69CA17C");
                personalInfoEntity.LoginId = "chisumiAoyama@gmail.com";
                personalInfoEntity.Password = "abcde";
                personalInfoEntity.MobileNumber = "09011223344";
                personalInfoEntity.Sex = Sex.Female;
                personalInfoEntity.Birthdate = new DateTime(1995, 3, 27);
                personalInfoEntity.EmailAddress1 = "Aoyama@gmail.com";
                personalInfoEntity.EmailAddress2 = "Aoyama2@gmail.com";
                personalInfoEntity.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                personalInfoEntity.CreateDate = DateTime.Now;
                personalInfoEntity.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                personalInfoEntity.UpdateDate = DateTime.Now;
                await personalInfoEntityRepository.Add(personalInfoEntity);

                //Getting
                var getPersonalInfoEntity = personalInfoEntityRepository.Get(personalInfoEntity.PersonId).Result;

                Assert.AreEqual(getPersonalInfoEntity.PersonId, personalInfoEntity.PersonId);
  
                Assert.AreEqual(getPersonalInfoEntity.MobileNumber, personalInfoEntity.MobileNumber);
                Assert.AreEqual(getPersonalInfoEntity.Sex, personalInfoEntity.Sex);
                Assert.AreEqual(getPersonalInfoEntity.Birthdate, personalInfoEntity.Birthdate);
                Assert.AreEqual(getPersonalInfoEntity.EmailAddress1, personalInfoEntity.EmailAddress1);

                //Updating
                personalInfoEntity.MobileNumber = "09091068083";
                personalInfoEntity.Sex = Sex.Male;
                personalInfoEntity.Birthdate = new DateTime(1971, 7, 28);
                personalInfoEntity.EmailAddress1 = "chisumi.aoyama@gmail.com";
                personalInfoEntity.EmailAddress2 = "chisumi2@gmail.com";
                await personalInfoEntityRepository.Update(personalInfoEntity);
                var updatepersonalInfoEntity = await personalInfoEntityRepository.Get(personalInfoEntity.PersonId);
                Assert.AreEqual(updatepersonalInfoEntity.PersonId, personalInfoEntity.PersonId);
                Assert.AreEqual(updatepersonalInfoEntity.MobileNumber, personalInfoEntity.MobileNumber);
                Assert.AreEqual(updatepersonalInfoEntity.Sex, personalInfoEntity.Sex);
                Assert.AreEqual(updatepersonalInfoEntity.Birthdate, personalInfoEntity.Birthdate);
                Assert.AreEqual(updatepersonalInfoEntity.EmailAddress1, personalInfoEntity.EmailAddress1);
                Assert.AreEqual(updatepersonalInfoEntity.EmailAddress2, personalInfoEntity.EmailAddress2);

                //Removing
                await personalInfoEntityRepository.Remove(personalInfoEntity);
                var resultpersonalInfoEntity = personalInfoEntityRepository.Get(personalInfoEntity.PersonId).Result;
                Assert.AreEqual(resultpersonalInfoEntity, null);
            }
        }

    }
}
