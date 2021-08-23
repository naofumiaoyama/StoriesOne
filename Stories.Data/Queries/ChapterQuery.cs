
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Stories.Domain.Model;
using Stories.Data.Queries.Interface;
using Dapper;

namespace Stories.Data.Queries
{
    public class ChapterQuery : IChapterQuery
    {
        /// <summary>
        /// Getting Chapters
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>

        public async Task<IDictionary<Guid, Chapter>> Get(Guid guid)
        {
            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                connection.ConnectionString = DatabaseContext.DbConnectionString;
                await connection.OpenAsync();

                var query = "Select bs.* from Bodies bs " +
                            "Where CAST(bs.StoryId as uniqueidentifier) = CAST('" + guid + "' as uniqueidentifier)";

                var chapters =  connection.QueryAsync(query).Result.Select(row =>
                new Chapter((Guid)row.Id, (int)row.ChapterNumber, (string)row.Content) { });

                await connection.CloseAsync();

                var dic = chapters.ToDictionary(b => b.Id);
                return dic;
            }
        }
    }
}
