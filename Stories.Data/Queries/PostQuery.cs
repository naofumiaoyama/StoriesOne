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
        public async Task<IDictionary<Guid, PostModel>> Get(Guid guid)
        {
            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                connection.ConnectionString = DatabaseContext.DbConnectionString;
                await connection.OpenAsync();

                var query = @"Select ps.* from Posts ps " +
                             "Where CAST(ps.TimelineId as uniqueidentifier) = CAST('" + guid + "' as uniqueidentifier)";
                
                var posts = await connection.QueryAsync<PostModel>(query);
                
                await connection.CloseAsync();
                var dic = posts.ToDictionary(f => f.Id);
                return dic;

            }
        }
    }
}
