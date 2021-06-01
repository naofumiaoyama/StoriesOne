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
            await _context.Timelines.AddAsync(timeline);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Timeline timeline)
        {
            _context.Timelines.Remove(timeline);
            await _context.SaveChangesAsync();
        }

        public async Task<Timeline> Get(Guid timelineId)
        {
            return await _context.Timelines.FindAsync(timelineId);
        }
      
        public async Task Update(Timeline timeline)
        {
            _context.Timelines.Update(timeline);
            await _context.SaveChangesAsync();
        }
    }
}
