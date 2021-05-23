using Stories.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        protected DatabaseContext _context;

        public PostRepository(DatabaseContext context)
        {
            _context = context;
        }


        public async Task Add(Post post)
        {
            await _context.AddAsync(post);
        }

        public async Task Delete(Post post)
        {
            _context.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task<Post> Get(Guid id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task Update(Post post)
        {
            _context.Update(post);
            await _context.SaveChangesAsync();
        }
    }
}
