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
            User user = new User();
            user.Id = Guid.Parse("ABC5DFFF-0109-4FCF-9512-41FF73BD24E7");
            user.PersonType = Domain.Model.PersonType.User;
            user.FirstName = "FirstName";
            user.MiddleName = "MiddleName";
            user.LastName = "LastName";
            user.DisplayName = "F.L";
            user.LivingPlace = "TokyoCity";
            user.Occupation = "Engineer";
            
            await userUnitOfWork.CreateUser(user);

            using (var context = new DatabaseContext())
            {
                GenericRepository<PersonEntity> personRepository = new GenericRepository<PersonEntity>(context);
                var person = await personRepository.Get(user.Id);

                Assert.AreEqual(user.Id, person.Id);
                Assert.AreEqual(user.PersonType.ToString(), person.PersonType.ToString());
                Assert.AreEqual(user.FirstName, person.FirstName);

                await personRepository.Remove(person);
            }
        }
    }
}

