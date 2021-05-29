using Stories.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Repositories
{
    public class TimelineRepository : ITimelineRepository
    {
        protected DatabaseContext _context;

        public TimelineRepository(DatabaseContext context)
        {
            _context = context;
        }


        public async Task Add(Timeline timeline)
        {
            await _context.AddAsync(timeline);
        }

        public async Task Delete(Timeline timeline)
        {
            _context.Remove(timeline);
            await _context.SaveChangesAsync();
        }

        public async Task<Timeline> Get(Guid personId)
        {
            return await _context.Timelines.FindAsync(personId);
        }

        public async Task Update(Timeline timeline)
        {
            _context.Update(timeline);
            await _context.SaveChangesAsync();
        }
    }
}
