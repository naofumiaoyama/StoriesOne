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
        public async Task<User> Get(Guid guid)
        {
            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                connection.ConnectionString = "server = localhost\\MSSQLSERVER01; database = Stories; integrated security = true";
                await connection.OpenAsync();
            
                var query = @"Select pe.*, pc.*, pi.* from People pe " +
                            "Inner Join Pictures pc on pe.ProfilePictureId = pc.Id " +
                            "Inner Join PersonalInfos pi on pe.Id = pi.PersonId " +
                            "Where CAST(pe.Id as uniqueidentifier) = CAST('" + guid + "' as uniqueidentifier)";
                IEnumerable<User> user = null;
                try
                {
                   user = await connection.QueryAsync<User, Picture, PersonalInfo, User>
                  (query, (pe, pc, pi) =>
                  {
                      pe.ProfilePicture = pc;
                      pe.PersonalInfo = pi;
                      return pe;
                  },
                  splitOn: "Id, PersonId"
                  );
                    return user.FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    return user.FirstOrDefault();
                }
                finally
                {
                    await connection.CloseAsync();
                }

            }
        }
    }
}
