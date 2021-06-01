using Stories.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Repositories
{
   public interface ITimelineRepository
    {
        Task<Timeline> Get(Guid personId);
        Task Add(Timeline timeline);
        Task Update(Timeline timeline);
        Task Delete(Timeline timeline);
    }
}
