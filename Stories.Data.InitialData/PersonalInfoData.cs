﻿using Stories.Data.Entities;
using Stories.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.InitialData
{
   public class PersonalInfoData
    {
        public async Task MakeData()
        {
            using (var context = new DatabaseContext())
            {
                GenericRepository<PersonalInfoEntity> personalInfoRepository = new GenericRepository<PersonalInfoEntity>(context);
                PersonalInfoEntity personalInfo = new PersonalInfoEntity();
                personalInfo.PersonId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                personalInfo.LoginId = "naofumi.aoyoama@gmail.com";
                personalInfo.Password = "password";
                personalInfo.MobileNumber = "09091068083";
                personalInfo.Sex = Sex.Male;
                personalInfo.Birthdate = new DateTime(1971, 7, 28);
                personalInfo.MaritalStatus = MaritalStatus.Married;
                personalInfo.EmailAddress1 = "naofumi.aoyoama@gmail.com";
                personalInfo.EmailAddress2 = "janeaoyama@gmail.com";
                personalInfo.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                personalInfo.CreateDate = DateTime.Now;
                personalInfo.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                personalInfo.UpdateDate = DateTime.Now;
                await personalInfoRepository.Add(personalInfo);

                PersonalInfoEntity personalInfo2 = new PersonalInfoEntity();
                personalInfo2.PersonId = Guid.Parse("F7A70CB7-F46D-4A94-88CD-6B0284CBE96F");
                personalInfo2.LoginId = "albiosjenalyn27@gmail.com";
                personalInfo2.Password = "abcd";
                personalInfo2.MobileNumber = "08035841995";
                personalInfo2.Sex = Sex.Female;
                personalInfo2.Birthdate = new DateTime(1995, 3, 27);
                personalInfo2.EmailAddress1 = "albiosjenalyn27@gmail.com";
                personalInfo2.EmailAddress2 = "jenaoyama@gmail.com";
                personalInfo2.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                personalInfo.CreateDate = DateTime.Now;
                personalInfo2.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                personalInfo2.UpdateDate = DateTime.Now;
                await personalInfoRepository.Add(personalInfo2);

            }
        }

        public async Task DeleteData()
        {
            using (var context = new DatabaseContext())
            {
                GenericRepository<PersonalInfoEntity> personalInfoRepository = new GenericRepository<PersonalInfoEntity>(context);
                var personinfo1 = personalInfoRepository.Get(Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F")).Result;
                if (personinfo1 != null) { await personalInfoRepository.Remove(personinfo1); }

                var personinfo2 = personalInfoRepository.Get(Guid.Parse("F7A70CB7-F46D-4A94-88CD-6B0284CBE96F")).Result;
                if (personinfo2 != null) { await personalInfoRepository.Remove(personinfo2); }

               
            }
        }

    }
}
