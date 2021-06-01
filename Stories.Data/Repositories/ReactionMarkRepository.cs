using Stories.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Repositories
{
    public class ReactionMarkRepository : IReactionMarkRepository
    {
        protected DatabaseContext _context;

        public ReactionMarkRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<ReactionMark> Get(Guid id)
        {
            return await _context.ReactionMarks.FindAsync(id);
        }

        public async Task Add(ReactionMark reactionMark)
        {
            await _context.ReactionMarks.AddAsync(reactionMark);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ReactionMark reactionMark)
        {
            _context.ReactionMarks.Remove(reactionMark);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ReactionMark reactionMark)
        {
            _context.ReactionMarks.Update(reactionMark);
            await _context.SaveChangesAsync();
        }
    }
}
