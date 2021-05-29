using Stories.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Repositories
{
   public interface IAddressRepository
    {
        Task<Address> Get(int Id);
        Task Add(Address address);
        Task Update(Address address);
        Task Remove(Address address);
    }
}
