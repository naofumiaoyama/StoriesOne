using System;
using System.Threading.Tasks;
using AutoMapper;
using Stories.Domain.Model;
using Stories.Data.Entities;

namespace Stories.Data.Repositories
{
    public class UserUnitOfWork
    {
        public UserUnitOfWork()
        {
        }

        public async Task CreateUser(User user)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, PersonEntity>());

            GenericRepository<PersonEntity> personRepository = new GenericRepository<PersonEntity>(new DatabaseContext());
          

            var mapper = new Mapper(config);
            var personEntity = mapper.Map<PersonEntity>(user);

            await personRepository.Add(personEntity);

        }
    }
}
