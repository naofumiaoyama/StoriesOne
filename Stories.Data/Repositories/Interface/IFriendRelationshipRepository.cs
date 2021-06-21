using Stories.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Repositories.Interface
{
   public interface IFriendRelationshipRepository
    {
        Task<FriendRelationship> Get(Guid Id);
        Task Add(FriendRelationship friendRelationship);
        Task Update(FriendRelationship friendRelationship);
        Task Remove(FriendRelationship friendRelationship);
    }
}
