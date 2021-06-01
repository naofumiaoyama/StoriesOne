using Stories.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Repositories
{
   public  interface IPictureRepository
    {
        Task<Picture> Get(Guid id);
        Task Add(Picture photo);
        Task Update(Picture photo);
        Task Delete(Picture photo);
    }
}
