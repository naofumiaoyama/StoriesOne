using Stories.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Repositories
{
  public  interface ICommentRepository
    {
        Task<Comment> Get(int id);
        Task Add(Comment comment);
        Task Update(Comment comment);
        Task Delete(Comment comment);
    }
}
