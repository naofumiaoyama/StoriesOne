using Stories.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Repositories
{
    public interface IStroryRepoisitory
    {
        Task<Story> Get(Guid guid);
        Task Add(Story story);
        Task Update(Story story);
        Task Delete(Story story);
    }
}
