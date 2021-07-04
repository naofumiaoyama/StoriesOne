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
            
                var query = @"Select pe.*, pc.*, tl.* from People pe " +
                            "Inner Join Pictures pc on pe.ProfilePictureId = pc.Id " +
                            "Inner Join Timelines tl on pe.Id = tl.PersonId " + 
                            "Where CAST(pe.Id as uniqueidentifier) = CAST('" + guid + "' as uniqueidentifier)";
                
                var user = await connection.QueryAsync<User, Picture, Timeline, User>
                (query, (pe, pc, tl) =>
                  {
                      pe.ProfilePicture = pc;
                      pe.Timeline = tl;
                      return pe;
                  },
                  splitOn: "Id, PersonId"
                );
                
                await connection.CloseAsync();
                
                return user.FirstOrDefault();

            }
        }
    }
}
