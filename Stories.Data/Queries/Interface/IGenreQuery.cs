using System;
using System.Threading.Tasks;
using Stories.Domain.Model;

namespace Stories.Data.Queries.Interface
{
   public interface IGenreQuery
   {
        public Task<Genre> Get(Guid id);
    }
}
