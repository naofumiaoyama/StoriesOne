using Stories.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stories.Data.Repositories
{
   public interface IBodyRepository
   {
        Task<Body> Get(Guid Id);
        Task Add(Body body);
        Task Update(Body body);
        Task Remove(Body body);
   }
}

