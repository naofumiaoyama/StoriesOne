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

        public async Task Add(ReactionMark reactionMark)
        {
            await _context.AddAsync(reactionMark);
        }

        public async Task Delete(ReactionMark reactionMark)
        {
            _context.Remove(reactionMark);
            await _context.SaveChangesAsync();
        }

        public async Task<ReactionMark> Get(string Url)
        {
            return await _context.ReactionMarks.FindAsync(Url);
        }

        public async Task Update(ReactionMark reactionMark)
        {
            _context.Update(reactionMark);
            await _context.SaveChangesAsync();
        }
    }
}
