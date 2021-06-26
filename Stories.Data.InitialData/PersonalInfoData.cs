using Stories.Data.Entities;
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
                PersonalInfoRepository personalInfoRepository = new PersonalInfoRepository(context);
                PersonalInfo personalInfo = new PersonalInfo();
                personalInfo.PersonId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                personalInfo.LoginId = "naofumi.aoyoama@gmail.com";
                personalInfo.Password = "pass";
                personalInfo.MobileNumber = "09091068083";
                personalInfo.Sex = Sex.Male;
                personalInfo.Birthdate = new DateTime(1971, 7, 28);
                personalInfo.MaritalStatus = MaritalStatus.Married;
                personalInfo.EmailAddress1 = "naofumi.aoyoama@gmail.com";
                personalInfo.EmailAddress2 = "janeaoyama@gmail.com";
                await personalInfoRepository.Add(personalInfo);

                PersonalInfo personalInfo2 = new PersonalInfo();
                personalInfo2.PersonId = Guid.Parse("F7A70CB7-F46D-4A94-88CD-6B0284CBE96F");
                personalInfo2.MobileNumber = "08035841995";
                personalInfo2.Sex = Sex.Female;
                personalInfo2.Birthdate = new DateTime(1995, 3, 27);
                personalInfo2.EmailAddress1 = "albiosjenalyn27@gmail.com";
                personalInfo2.EmailAddress2 = "naoaoyama@gmail.com";
                await personalInfoRepository.Add(personalInfo2);
            }
        }

        public async Task DeleteData()
        {
            using (var context = new DatabaseContext())
            {
                PersonalInfoRepository personalInfoRepository = new PersonalInfoRepository(context);
                var personinfo1 = personalInfoRepository.Get(Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F")).Result;
                if (personinfo1 != null) { await personalInfoRepository.Remove(personinfo1); }

                var personinfo2 = personalInfoRepository.Get(Guid.Parse("F7A70CB7-F46D-4A94-88CD-6B0284CBE96F")).Result;
                if (personinfo2 != null) { await personalInfoRepository.Remove(personinfo2); }

            }
        }

    }
}
