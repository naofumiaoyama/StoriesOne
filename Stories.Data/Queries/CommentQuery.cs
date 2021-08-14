
using Dapper;
using Stories.Data.Queries.Interface;
using Stories.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Queries
{
    public class CommentQuery : ICommentQuery
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public async Task<Comment> Get(Guid guid)
        {
            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                connection.ConnectionString = DatabaseContext.DbConnectionString;
                await connection.OpenAsync();

                var query = @"Select cs.* from Comments cs" +
              " Where CAST(cs.CommentPersonId as uniqueidentifier) = CAST('" + guid + "' as uniqueidentifier)";

                var comment = await connection.QueryAsync<Comment>(query);

                await connection.CloseAsync();

                return comment.FirstOrDefault();
            }
        }
    }
}