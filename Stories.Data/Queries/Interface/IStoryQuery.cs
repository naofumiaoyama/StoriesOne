using Stories.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Queries.Interface
{
   public interface IStoryQuery
    {
        Task<IDictionary<Guid, Story>> Get(Guid guid);
    }
}
