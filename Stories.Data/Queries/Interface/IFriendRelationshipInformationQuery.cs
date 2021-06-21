using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stories.Domain.Model;
using Stories.Data.Queries.Interface;
using System.Data.SqlClient;

namespace Stories.Data.Queries.Interface
{
 public  interface IFriendRelationshipInformationQuery
    {
        Task<FriendRelationship> Get(Guid guid);
    }
}
