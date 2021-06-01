using Stories.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Repositories
{
  public  interface IPersonalInfoRepository
    {
        Task<PersonalInfo> Get(int Id);
        Task Add(PersonalInfo personalInfo);
        Task Update(PersonalInfo personalInfo);
        Task Delete(PersonalInfo personalInfo);
    }
}
