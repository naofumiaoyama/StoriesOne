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
    /// <summary>
    /// 
    /// </summary>
    public class ReactionMarkQuery : IReactionMarkQuery
    {
        public async Task<IDictionary<Guid, ReactionMark>> Get(Guid postId)
        {
            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                connection.ConnectionString = DatabaseContext.DbConnectionString;
                await connection.OpenAsync();

                var query = @"select rs.* from ReactionMarks rs " +
               " Where CAST(rs.PostId as uniqueidentifier) = CAST('" + postId + "' as uniqueidentifier)";

                var reactionMarks = connection.QueryAsync(query).Result.Select(row =>
                new ReactionMark((Guid)row.Id,
                               // (Guid)row.PostId,
                                (string)row.Name,
                                (string)row.Url,
                                (bool)row.Clicked)
                {    
               });

                await connection.CloseAsync();

                var dic = reactionMarks.ToDictionary(r => r.Id);
                return dic;                              
            }
        }
    }
}
