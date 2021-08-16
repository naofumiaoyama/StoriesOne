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

        public async Task CreateUser(User userModel)
        { 
            var userConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, Entities.Person>();
                cfg.CreateMap<Stories.Domain.Model.PersonalInfo, Entities.PersonalInfo>();
            });

            GenericRepository<Entities.Person> personRepository = 
                new GenericRepository<Entities.Person>(new DatabaseContext());
            GenericRepository<Entities.PersonalInfo> personInfoRepository = 
                new GenericRepository<Entities.PersonalInfo>(new DatabaseContext());

            var userMapper = new Mapper(userConfig);
            
            var personEntity = userMapper.Map<Entities.Person>(userModel);
            
            personEntity.CreateDate = DateTime.Now;
            personEntity.CreateUserId = userModel.Id;
            personEntity.UpdateDate = DateTime.Now;
            personEntity.UpdateUserId = userModel.Id;

            personEntity.PersonalInfo.CreateDate = DateTime.Now;
            personEntity.PersonalInfo.CreateUserId = userModel.Id;
            personEntity.PersonalInfo.UpdateDate = DateTime.Now;
            personEntity.PersonalInfo.UpdateUserId = userModel.Id;

            await personRepository.Add(personEntity);
        }
    }
}
