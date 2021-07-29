using Stories.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Queries.Interface
{
  public  interface ICommentQuery
    {
        public Task<Comment> Get(Guid guid);
    }
}
