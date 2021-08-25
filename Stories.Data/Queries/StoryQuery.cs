using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stories.Data.Queries.Interface;
using Stories.Domain.Model;
namespace Stories.Data.Queries
{
    public class StoryQuery : IStoryQuery
    {
        /// <summary>
        /// Getting Story
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public async Task<IDictionary<Guid, Story>> Get(Guid personId)
        {
            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                connection.ConnectionString = DatabaseContext.DbConnectionString;
                await connection.OpenAsync();

                var query = @"Select sto.* from Stories sto " +
                             "where CAST(sto.PersonId as uniqueidentifier) = CAST('" + personId + "' as uniqueidentifier)";

                var stories = connection.QueryAsync(query).Result.Select(row =>
                new Story((Guid)row.Id, (string)row.Title, (string)row.Summary, (StoryType) row.StoryType) {
                    Thoughts = row.Thoughts
                });

                await connection.CloseAsync();

                var dic = stories.ToDictionary(s => s.Id);
                return dic;

            }
        }
    }
}
