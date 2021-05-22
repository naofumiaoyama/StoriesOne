using Stories.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        protected DatabaseContext _context;

        public PhotoRepository(DatabaseContext context)
        {
            _context = context;
        }


        public async Task Add(Photo photo)
        {
            await _context.AddAsync(photo);
        }

        public async Task Delete(Photo photo)
        {
            _context.Remove(photo);
            await _context.SaveChangesAsync();
        }

        public async Task<Photo> Get(int id)
        {
            return _context.Photos.Find(id);
        }

        public async Task Update(Photo photo)
        {
            _context.Update(photo);
            await _context.SaveChangesAsync();
        }
    }
}
