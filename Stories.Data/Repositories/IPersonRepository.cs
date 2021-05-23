using Stories.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Repositories
{
    public interface IPersonRepository
    {
        Task<Person> Find(Guid guid);
        Task Add(Person person);
        Task Update(Person person);
        void Remove(Person person);
    }
}