using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Stories.Data.Queries.Interface;
using Stories.Domain.Model;


namespace Stories.Data.Queries
{
    public class PictureQuery : IPictureQuery
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Picture> Get(Guid Id)
        {
            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                connection.ConnectionString = DatabaseContext.DbConnectionString;
                await connection.OpenAsync();

                var query = @"select pics.* from Pictures pics " +
             "Where CAST(pics.Id as uniqueidentifier) = CAST( '" + Id + "' as uniqueidentifier)";

                var picture = connection.QueryAsync(query).Result.Select(row =>
                new Picture((Guid)row.Id,
                    (PictureOwnerType)row.PictureOwnerType,
                    (string)row.Url)
                {

                }).FirstOrDefault();

                await connection.CloseAsync();
                return picture;
            }
        }
    }
}
