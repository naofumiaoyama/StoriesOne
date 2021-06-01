using Stories.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Repositories
{
    public class BiographyRepository : IBiographyRepository
    {
        protected DatabaseContext _context;

        public BiographyRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Biography> Get(Guid id)
        {
            return await _context.Biographies.FindAsync(id);
        }

        public async Task Add(Biography biography)
        {
            await _context.Biographies.AddAsync(biography);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Biography biography)
        {
            _context.Biographies.Remove(biography);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Biography biography)
        {
            _context.Biographies.Update(biography);
            await _context.SaveChangesAsync();
        }

    }
}
