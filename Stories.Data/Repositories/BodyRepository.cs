using Stories.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Repositories
{
    public class BodyRepository : IBodyRepository
    {
        protected DatabaseContext _context;

        public BodyRepository(DatabaseContext context)
        {
            _context = context;
        }


        public async Task Add(Body body)
        {
            await _context.AddAsync(body);
            await _context.SaveChangesAsync();
        }
   
        public async Task<Body> Get(Guid Id)
        {
            return await _context.Bodies.FindAsync(Id);
        }
      
        public async Task Remove(Body body)
        {
            _context.Remove(body);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Body body)
        {
            _context.Remove(body);
            await _context.SaveChangesAsync();
        }
    }
}
