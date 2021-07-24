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
            var userConfig = new MapperConfiguration(cfg => cfg.CreateMap<User, PersonT>());
            var userInfoConfig = new MapperConfiguration(cfg => cfg.CreateMap<PersonalInfo, PersonalInfoT>());
            
            GenericRepository<PersonT> personRepository = 
                new GenericRepository<PersonT>(new DatabaseContext());
            GenericRepository<PersonalInfoT> personInfoRepository = 
                new GenericRepository<PersonalInfoT>(new DatabaseContext());

            var userMapper = new Mapper(userConfig);
            var personInfoMapper = new Mapper(userInfoConfig);

            var personEntity = userMapper.Map<PersonT>(user);
            var personInfoEntity = personInfoMapper.Map<PersonalInfoT>(user.PersonalInfo);

            personEntity.CreateDate = DateTime.Now;
            personEntity.CreateUserId = user.Id;
            personEntity.UpdateDate = DateTime.Now;
            personEntity.UpdateUserId = user.Id;

            await personRepository.Add(personEntity);

        }
    }
}
