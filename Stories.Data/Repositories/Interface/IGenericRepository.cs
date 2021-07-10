using Stories.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(Guid guid);
        Task Add(T entity);
        Task Update(T entity);
        Task Remove(T entity);
    }
}