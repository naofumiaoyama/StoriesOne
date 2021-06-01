using Stories.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Repositories
{
    public class PictureRepository : IPictureRepository
    {
        protected DatabaseContext _context;

        public PictureRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Picture> Get(Guid id)
        {
            return await _context.Pictures.FindAsync(id);
        }

        public async Task Add(Picture photo)
        {
            await _context.Pictures.AddAsync(photo);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Picture photo)
        {
            _context.Remove(photo);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Picture photo)
        {
            _context.Pictures.Update(photo);
            await _context.SaveChangesAsync();
        }
    }
}
