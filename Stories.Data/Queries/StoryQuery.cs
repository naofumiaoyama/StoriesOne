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
        public async Task<IDictionary<Guid, StoryModel>> Get(Guid guid)
        {
            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                connection.ConnectionString = DatabaseContext.DbConnectionString;
                await connection.OpenAsync();

                var query = @"select sto.* from Stories sto "+
               "where CAST(sto.AuthorPersonId as uniqueidentifier) = CAST('" + guid + "' as uniqueidentifier)";

                var stories = await connection.QueryAsync<StoryModel>(query);

                await connection.CloseAsync();

                var dic = stories.ToDictionary(s => s.Id);
                return dic;

            }
        }
    }
}
