using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stories.Data.Entities;
using Stories.Data.Repositories;
namespace Stories.Data.InitialData
{
    public class PersonData
    {
        public async Task MakeData()
        {
            using (var context = new DatabaseContext())
            {
                PersonRepository personRepository = new PersonRepository(context);
                Person person = new Person();
                person.Id = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                person.FirstName = "Naofumi";
                person.MiddleName = "Makio";
                person.LastName = "Aoyama";
                person.LoginId = "naofumi.aoyoama@gmail.com";
                person.Password = "pass";
                person.DisplayName = "N.A";
                person.SelfIntroduction = "私の自己紹介";
                person.LivingPlace = "TokorozawaCity";
                person.Occupation = "Engineer";
                person.MaritalStatus = MaritalStatus.Married;
                await personRepository.Add(person);

                Person person2 = new Person();
                person2.Id = Guid.Parse("F7A70CB7-F46D-4A94-88CD-6B0284CBE96F");
                person2.PersonType = PersonType.User;
                person2.FirstName = "Jenalyn";
                person2.MiddleName = "Makio";
                person2.LastName = "Aoyama";
                person2.LoginId = "jen@gmail.com";
                person2.Password = "pass";
                person2.DisplayName = "J.A";
                person2.SelfIntroduction = "私の自己紹介";
                person2.LivingPlace = "MandaueCity";
                person2.Occupation = "Engineer";
                person2.MaritalStatus = MaritalStatus.Married;
                await personRepository.Add(person2);
            }
        }

        public async Task DeleteData()
        {
            using (var context = new DatabaseContext())
            {
                PersonRepository personRepository = new PersonRepository(context);
                var person1 = personRepository.Get(Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F")).Result;
                if( person1 != null) { await personRepository.Remove(person1);  }

                var person2 = personRepository.Get(Guid.Parse("F7A70CB7-F46D-4A94-88CD-6B0284CBE96F")).Result;
                if (person2 != null) { await personRepository.Remove(person2); }
               
            }
        }
    }
}
