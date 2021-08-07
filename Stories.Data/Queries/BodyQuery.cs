using Stories.Domain.Model;
using Stories.Data.Queries.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace Stories.Data.Queries
{
    public class BodyQuery : IBodyQuery
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>

        public async Task<IDictionary<Guid, BodyModel>> Get(Guid guid)
        {
            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                connection.ConnectionString = DatabaseContext.DbConnectionString;
                await connection.OpenAsync();

                var query = "Select bs.* from Bodies bs " +
                            "Where CAST(bs.StoryId as uniqueidentifier) = CAST('" + guid + "' as uniqueidentifier)";

                var bodies = await connection.QueryAsync<BodyModel>(query);

                await connection.CloseAsync();

                var dic = bodies.ToDictionary(b => b.Id);
                return dic;
            }
        }
    }
}
