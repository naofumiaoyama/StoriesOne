﻿using System;
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
        public async Task<IDictionary<Guid, Post>> Get(Guid timelineId)
        {
            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                connection.ConnectionString = DatabaseContext.DbConnectionString;
                await connection.OpenAsync();

                var query = @"Select ps.* from Posts ps " +
                             "Where CAST(ps.TimelineId as uniqueidentifier) = CAST('" + timelineId + "' as uniqueidentifier)";
                
                var posts = connection.QueryAsync<Post>(query).Result.Select(row =>
                new Post((Guid)row.Id, (string)row.Title) { }); ;
                
                await connection.CloseAsync();
                var dic = posts.ToDictionary(f => f.Id);
                return dic;
            }
        }
    }
}
