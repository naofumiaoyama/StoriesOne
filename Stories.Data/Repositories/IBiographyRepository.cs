using Stories.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Repositories
{
   public interface IBiographyRepository
   {
        Task<Biography> Get(int id);
        Task Add(Biography biography);
        Task Update(Biography biography);
        Task Delete(Biography biography);
   }  
}
