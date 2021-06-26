using Stories.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Repositories
{
    public class StoryRepository : IStoryRepoisitory
    {
        protected DatabaseContext _context;

        public StoryRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Add(Story story)
        {
            await _context.Stories.AddAsync(story);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Story story)
        {
            _context.Stories.Remove(story);
            await _context.SaveChangesAsync();
        }

        public async Task<Story> Get(Guid guid)
        {
            return await _context.Stories.FindAsync(guid);
        }

        public async Task Update(Story story)
        {
            _context.Stories.Update(story);
            await _context.SaveChangesAsync();
        }
    }
}
