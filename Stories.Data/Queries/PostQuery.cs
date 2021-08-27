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
    public class PostQuery : IPostQuery
    {
        /// <summary>
        /// Getting Posts
        /// </summary>
        /// <param name="guid">Timeline.Id</param>
        /// <returns></returns>
        public async Task<Post> Get(Guid Id)
        {
            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                connection.ConnectionString = DatabaseContext.DbConnectionString;
                await connection.OpenAsync();

                var query = @"Select ps.* from Posts ps " +
                             "Where CAST(ps.Id as uniqueidentifier) = CAST('" + Id + "' as uniqueidentifier)";

                var post = connection.QueryAsync(query).Result.Select(row =>
                new Post((Guid)row.Id,
                        (string)row.Title,
                        (DateTime)row.postDatetime,
                        (Story)row.Story,
                        null)
                {
                }).FirstOrDefault();

                await connection.CloseAsync();

                return post;
            }
        }
    }
}
