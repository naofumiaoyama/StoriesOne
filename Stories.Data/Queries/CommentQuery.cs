
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
    public class CommentQuery : ICommentQuery
    {
        /// <summary>
        /// Getting Comments
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public async Task<IDictionary<Guid, Comment>> Get(Guid postId)
        {
            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                connection.ConnectionString = DatabaseContext.DbConnectionString;
                await connection.OpenAsync();

                var query = @"Select cs.* from Comments cs" +
              " Where CAST(cs.PostId as uniqueidentifier) = CAST('" + postId + "' as uniqueidentifier)";

                var comments = connection.QueryAsync(query).Result.Select(row =>
                new Comment((Guid)row.Id,
                (string)row.CommentText,
                (DateTime)row.PostTime)
                {
                });

                await connection.CloseAsync();
                var dic = comments.ToDictionary(f => f.Id);

                return dic;
            }
        }
    }
}