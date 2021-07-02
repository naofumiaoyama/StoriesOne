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
    public class FriendQuery : IFriendQuery
    {
        /// <summary>
        /// Getting Address
        /// </summary>
        /// <param name="guid">People.Id</param>
        /// <returns></returns>
        public async Task<IList<User>> Get(Guid guid)
        {
            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                connection.ConnectionString = DatabaseContext.DbConnectionString;
                await connection.OpenAsync();

                var query = @"Select pl.* from People pl " +
                             "Where pl.Id In( " +
                             "Select fl.FriendPersonId From FriendRelationships fl " +
                             "Where CAST(fl.PersonId as uniqueidentifier) = CAST('" + guid + "' as uniqueidentifier))";
                
                var friends = await connection.QueryAsync<User>(query);
                
                await connection.CloseAsync();
                
                return (IList<User>)friends;

            }
        }
    }
}
