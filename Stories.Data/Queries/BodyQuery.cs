using Stories.Data.Entities;
using Stories.Data.Queries.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Queries
{
    public class BodyQuery : IBodyQuery
    {
        public Task<IDictionary<Guid, Body>> Get(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}
