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
    public class CharacterQuery : ICharacterQuery
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>

      public async Task<IDictionary<Guid, Character>> Get(Guid guid)
        {
            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                connection.ConnectionString = DatabaseContext.DbConnectionString;
                await connection.OpenAsync();

                var query = @"Select crs.* from Characters crs " +
                             "Where CAST(crs.StoryId as uniqueidentifier) = CAST('" + guid + "' as uniqueidentifier)";

                var characters = connection.QueryAsync(query).Result.Select(row =>
                new Character((Guid)row.Id, (string)row.Name, (string)row.Description)
                {
                });

                await connection.CloseAsync();
                var dic = characters.ToDictionary(f => f.Id);
                return dic;
            }
        }
    }
}
