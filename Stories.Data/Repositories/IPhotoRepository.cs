using Stories.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Repositories
{
   public  interface IPhotoRepository
    {
        Task<Photo> Get(int id);
        Task Add(Photo photo);
        Task Update(Photo photo);
        Task Delete(Photo photo);
    }
}
