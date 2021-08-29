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
        /// <param name="guid">Address.Id</param>
        /// <returns></returns>
        public async Task<Address> Get(Guid id)
        {
            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                connection.ConnectionString = DatabaseContext.DbConnectionString;
                await connection.OpenAsync();
            
                var query = @"Select ad.* from Addresses ad " +
                            "Where CAST(ad.Id as uniqueidentifier) = CAST('" + id + "' as uniqueidentifier)";

                var address = connection.QueryAsync(query).Result.Select(row =>
                new Address((Guid)row.Id, 
                            (string)row.PostalCode,
                            (CountryCode)row.CountryCode,
                            (string)row.CountryName,
                            (string)row.PrefectureName,
                            (string)row.StateName,
                            (string)row.CityName,
                            (string)row.TownName,
                            (string)row.Street,
                            (string)row.Others)
                {
                });
               
                await connection.CloseAsync();

                return address.FirstOrDefault();
            }
                
        }
    }
}
