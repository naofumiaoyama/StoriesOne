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
        Task<Address> Get(Guid PersonId);
        Task Add(Address address);
        void Update(Address address);
        Task Delete(Address address);
    }
}
