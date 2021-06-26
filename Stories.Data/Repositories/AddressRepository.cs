using Stories.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Repositories
{
    public class AddressRepository : IAddressRepository 
    {
        protected DatabaseContext _context;

        public AddressRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Add(Address address)
        {
            await _context.AddAsync(address);
            await _context.SaveChangesAsync();
        }

        public async Task<Address> Get(Guid id)
        {
            return await _context.Addresses.FindAsync(id);
        }

        public async Task Remove(Address address)
        {
             _context.Remove(address);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Address address)
        {
            _context.Update(address);
            await _context.SaveChangesAsync();

        }
    }
}
