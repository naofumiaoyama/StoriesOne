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
    public class UserQuery : IUserQuery
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="guid">People.Id</param>
        /// <returns></returns>
        public async Task<User> Get(Guid guid)
        {
            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                connection.ConnectionString = DatabaseContext.DbConnectionString;
                await connection.OpenAsync();
            
                var query = @"Select pe.* from People pe " +
                            "Where CAST(pe.Id as uniqueidentifier) = CAST('" + guid + "' as uniqueidentifier)";

                var user = await connection.QueryAsync<User>(query);
                
                await connection.CloseAsync();
                
                return user.FirstOrDefault();

            }
        }
    }
}
