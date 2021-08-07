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

        public async Task CreateUser(UserModel userModel)
        {
            var userConfig = new MapperConfiguration(cfg => cfg.CreateMap<UserModel, Entities.Person>());
            var userInfoConfig = new MapperConfiguration(cfg => cfg.CreateMap<PersonalInfoModel, PersonalInfo>());

            GenericRepository<Entities.Person> personRepository = 
                new GenericRepository<Entities.Person>(new DatabaseContext());
            GenericRepository<Entities.PersonalInfo> personInfoRepository = 
                new GenericRepository<Entities.PersonalInfo>(new DatabaseContext());

            var userMapper = new Mapper(userConfig);
            var personInfoMapper = new Mapper(userInfoConfig);

            var personEntity = userMapper.Map<Entities.Person>(userModel);
            var personInfoEntity = personInfoMapper.Map<Entities.PersonalInfo>(userModel.PersonalInfo);

            // Set Encrypted Password
            personInfoEntity.EncryptedPassword = userModel.PersonalInfo.EncryptedPassword;

            personEntity.CreateDate = DateTime.Now;
            personEntity.CreateUserId = userModel.Id;
            personEntity.UpdateDate = DateTime.Now;
            personEntity.UpdateUserId = userModel.Id;

            personInfoEntity.CreateDate = DateTime.Now;
            personInfoEntity.CreateUserId = userModel.Id;
            personInfoEntity.UpdateDate = DateTime.Now;
            personInfoEntity.UpdateUserId = userModel.Id;

            await personRepository.Add(personEntity);
            await personInfoRepository.Add(personInfoEntity);
        }
    }
}
