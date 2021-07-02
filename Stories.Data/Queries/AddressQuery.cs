using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stories.Domain.Model;
using Stories.Data.Queries.Interface;
using System.Data.SqlClient;
using Dapper;

namespace Stories.Data.Queries
{
    public class AddressQuery : IAddressQuery
    {
        /// <summary>
        /// Getting Address
        /// </summary>
        /// <param name="guid">People.Id</param>
        /// <returns></returns>
        public async Task<IList<Address>> Get(Guid guid)
        {
            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                connection.ConnectionString = DatabaseContext.DbConnectionString;
                await connection.OpenAsync();
            
                var query = @"Select ad.* from Addresses ad " +
                            "Where CAST(ad.PersonId as uniqueidentifier) = CAST('" + guid + "' as uniqueidentifier)";
                
                var addresses = await connection.QueryAsync<Address>(query);
                
                await connection.CloseAsync();
                
                return (IList<Address>)addresses;

            }
        }
    }
}
