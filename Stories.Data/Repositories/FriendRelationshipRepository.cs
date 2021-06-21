using Stories.Data.Entities;
using Stories.Data.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Repositories
{
    public class FriendRelationshipRepository : IFriendRelationshipRepository
    {
        protected DatabaseContext _context;

        public FriendRelationshipRepository(DatabaseContext context)
        {
            _context = context;
        }


        public async Task Add(FriendRelationship friendRelationship)
        {
            await _context.AddAsync(friendRelationship);
            await _context.SaveChangesAsync();
        }

        public async Task<FriendRelationship> Get(Guid Id)
        {
           return await _context.FriendRelationships.FindAsync(Id);
        }

        public async Task Remove(FriendRelationship friendRelationship)
        {
           _context.Remove(friendRelationship);
            await _context.SaveChangesAsync();
        }

        public async Task Update(FriendRelationship friendRelationship)
        {
            _context.FriendRelationships.Update(friendRelationship);
            await _context.SaveChangesAsync();
        }
    }
}

