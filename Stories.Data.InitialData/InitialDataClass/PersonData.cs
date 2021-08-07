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
                GenericRepository<Person> personRepository = new GenericRepository<Person>(context);
                Person person = new Person();
                person.Id = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                person.PersonType = PersonType.User;
                person.FirstName = "Naofumi";
                person.MiddleName = "Makio";
                person.LastName = "Aoyama";
                person.DisplayName = "N.A";
                person.SelfIntroduction = "私の自己紹介";
                person.LivingPlace = "TokorozawaCity";
                person.Occupation = "Engineer";
                person.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                person.CreateDate = DateTime.Now;
                person.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                person.UpdateDate = DateTime.Now;
                await personRepository.Add(person);

                Person person2 = new Person();
                person2.Id = Guid.Parse("F7A70CB7-F46D-4A94-88CD-6B0284CBE96F");
                person2.PersonType = PersonType.User;
                person2.FirstName = "Jenalyn";
                person2.MiddleName = "Albios";
                person2.LastName = "Aoyama";
                person2.DisplayName = "J.A";
                person2.SelfIntroduction = "ジェナリンの自己紹介";
                person2.LivingPlace = "MandaueCity";
                person2.Occupation = "Engineer";
                person2.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                person2.CreateDate = DateTime.Now;
                person2.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                person2.UpdateDate = DateTime.Now;

                await personRepository.Add(person2);

                Person person3 = new Person();
                person3.Id = Guid.Parse("0389C8FF-2B0F-4215-8F47-DD58C69CA17C");
                person3.PersonType = PersonType.User;
                person3.FirstName = "Chisumi";
                person3.MiddleName = "Makio";
                person3.LastName = "Aoyama";
                person3.DisplayName = "C.A";
                person3.SelfIntroduction = "チスミの自己紹介";
                person3.LivingPlace = "坂町";
                person3.Occupation = "とくになし";
                person3.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                person3.CreateDate = DateTime.Now;
                person3.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                person3.UpdateDate = DateTime.Now;

                await personRepository.Add(person3);

                Person person4 = new Person();
                person4.Id = Guid.Parse("e62ae34a-840c-47d4-96a5-1dffdb5e61ce");
                person4.PersonType = PersonType.User;
                person4.FirstName = "Toya";
                person4.MiddleName = "Pokemon";
                person4.LastName = "Arai";
                person4.DisplayName = "T.A";
                person4.SelfIntroduction = "とーやの自己紹介";
                person4.LivingPlace = "池袋";
                person4.Occupation = "PublicOfficer";
                person4.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                person4.CreateDate = DateTime.Now;
                person4.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                person4.UpdateDate = DateTime.Now;

                await personRepository.Add(person4);
            }
        }

        public async Task DeleteData()
        {
            using (var context = new DatabaseContext())
            {
                GenericRepository<Person> personRepository = new GenericRepository<Person>(context);
                var person1 = personRepository.Get(Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F")).Result;
                if( person1 != null) { await personRepository.Remove(person1);  }

                var person2 = personRepository.Get(Guid.Parse("F7A70CB7-F46D-4A94-88CD-6B0284CBE96F")).Result;
                if (person2 != null) { await personRepository.Remove(person2); }

                var person3 = personRepository.Get(Guid.Parse("0389C8FF-2B0F-4215-8F47-DD58C69CA17C")).Result;
                if (person3 != null) { await personRepository.Remove(person3); }

                var person4 = personRepository.Get(Guid.Parse("e62ae34a-840c-47d4-96a5-1dffdb5e61ce")).Result;
                if (person4 != null) { await personRepository.Remove(person4); }

            }
        }
    }
}
