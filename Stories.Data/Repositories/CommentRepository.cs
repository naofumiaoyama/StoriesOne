using Stories.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        protected DatabaseContext _context;

        public CommentRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Add(Comment comment)
        {
            await _context.AddAsync(comment);
        }

        public async Task Delete(Comment comment)
        {
            _context.Remove(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<Comment> Get(int id)
        {
            return _context.Comments.Find( id);
        }

        public async Task Update(Comment comment)
        {
            _context.Update(comment);
            await _context.SaveChangesAsync();
        }
    }
}
