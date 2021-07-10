using System;
using Stories.Domain.Model;
using Stories.Data.Entities;
using System.Threading.Tasks;
namespace Stories.Data.Repositories
{
    public class UserUnitOfWork
    {
        public UserUnitOfWork()
        {
        }

        public async Task CreateUser(User user)
        {
            GenericRepository<PersonEntity> personRepository = new GenericRepository<PersonEntity>(new DatabaseContext());
            PersonEntity personEntity = new PersonEntity();

            personEntity.FirstName = user.FirstName;
            personEntity.MiddleName = user.MiddleName;
            personEntity.LastName = user.LastName;
            await personRepository.Add(personEntity);

        }
    }
}
