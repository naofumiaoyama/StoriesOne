using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Stories.Data.Queries.Interface;
using Stories.Domain.Model;

namespace Stories.Data.Queries.Interface
{
   public interface IReactionMarkQuery
   {
        Task<IDictionary<Guid, ReactionMark>> Get(Guid guid);
    }
}
