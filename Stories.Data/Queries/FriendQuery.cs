using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stories.Domain.Model;
using Stories.Data.Queries.Interface;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace Stories.Data.Queries
{
    public class FriendQuery : IFriendQuery
    {
        /// <summary>
        /// Getting Friends
        /// </summary>
        /// <param name="guid">PersonId</param>
        /// <returns></returns>
        public async Task<IDictionary<Guid, User>> Get(Guid personId)
        {
            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                connection.ConnectionString = DatabaseContext.DbConnectionString;
                await connection.OpenAsync();

                var query = @"Select pl.* from People pl " +
                             "Where pl.Id In( " +
                             "Select fl.FriendPersonId From FriendRelationships fl " +
                             "Where CAST(fl.PersonId as uniqueidentifier) = CAST('" + personId + "' as uniqueidentifier))";

                var friends = connection.Query(query).Select(row =>
                new User((Guid)row.Id,
                        (string)row.FirstName,
                        (string)row.LastName,
                        (string)row.NickName,
                        null,
                        (PersonType)row.PersonType,
                        (string)row.DisplayName,
                        (string)row.SelfIntroduction,
                        (string)row.LivingPlace,
                        (string)row.Occupation,
                        null, null, null)
                {
                });

                await connection.CloseAsync();

                return friends.ToDictionary(f => f.Id); ;
            }
        }
    }
}
