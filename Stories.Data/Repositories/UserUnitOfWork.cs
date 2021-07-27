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
            var userConfig = new MapperConfiguration(cfg => cfg.CreateMap<User, PersonEntity>());
            var userInfoConfig = new MapperConfiguration(cfg => cfg.CreateMap<PersonalInfo, PersonalInfoEntity>());
            
            GenericRepository<PersonEntity> personRepository = 
                new GenericRepository<PersonEntity>(new DatabaseContext());
            GenericRepository<PersonalInfoEntity> personInfoRepository = 
                new GenericRepository<PersonalInfoEntity>(new DatabaseContext());

            var userMapper = new Mapper(userConfig);
            var personInfoMapper = new Mapper(userInfoConfig);

            var personEntity = userMapper.Map<PersonEntity>(user);
            var personInfoEntity = personInfoMapper.Map<PersonalInfoEntity>(user.PersonalInfo);

            // Set Encrypted Password
            personInfoEntity.EncryptedPassword = user.PersonalInfo.EncryptedPassword;

            personEntity.CreateDate = DateTime.Now;
            personEntity.CreateUserId = user.Id;
            personEntity.UpdateDate = DateTime.Now;
            personEntity.UpdateUserId = user.Id;

            personInfoEntity.CreateDate = DateTime.Now;
            personInfoEntity.CreateUserId = user.Id;
            personInfoEntity.UpdateDate = DateTime.Now;
            personInfoEntity.UpdateUserId = user.Id;

            await personRepository.Add(personEntity);
            await personInfoRepository.Add(personInfoEntity);
        }
    }
}
