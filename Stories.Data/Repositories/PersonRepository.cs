using Stories.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        protected DatabaseContext _context;

        public PersonRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Add(Person person)
        {
            await _context.People.AddAsync(person);
            await _context.SaveChangesAsync();
        }

        public void Remove(Person person)
        {
            _context.People.Remove(person);
            _context.SaveChanges();
        }
        
        public async Task<Person> Find(Guid guid)
        {
            return await _context.People.FindAsync(guid);
        }

        public async Task Update(Person person)
        {
            _context.People.Update(person);
            await _context.SaveChangesAsync();
        }
    }
}
