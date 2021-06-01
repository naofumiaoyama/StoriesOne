using Stories.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Repositories
{
 public interface IPostRepository
    {
        Task<Post> Get(Guid id);
        Task Add(Post post);
        Task Update(Post post);
        Task Delete(Post post);
    }

}
