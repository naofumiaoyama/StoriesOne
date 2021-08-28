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
    public class GenreQuery : IGenreQuery
    {
        /// <summary>
        /// Getting Genre
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public async Task<Genre> Get(Guid id)
        {
            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                connection.ConnectionString = DatabaseContext.DbConnectionString;
                await connection.OpenAsync();

                var query = @"Select ge.* from Genres ge " +
                            "Where CAST(ge.Id as uniqueidentifier) = CAST('" + id + "' as uniqueidentifier)";

                var genre = connection.QueryAsync(query).Result.Select(row =>
                new Genre((Guid)row.Id,
                (string)row.Name,
                    (GenreType)row.GenreType)
                {
                }).FirstOrDefault();

                await connection.CloseAsync();

                return genre;
            }
        }
    }
}
