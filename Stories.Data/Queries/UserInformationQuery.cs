using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stories.Domain.Model;
using Stories.Data.Queries.Interface;
using System.Data.SqlClient;

namespace Stories.Data.Queries
{
    public class UserInformationQuery : IUserInformationQuery
    {
        public async Task<User> Get(Guid guid)
        {
            User user = new User();

            using (var connection = new SqlConnection("server = localhost\\MSSQLSERVER01; database = Stories; integrated security = true"))
            {
                var command = new SqlCommand("" +
"select p.Id, DisplayName, pic.Id, pic.PictureType, pic.Url from People p " +
"INNER JOIN Pictures pic on p.Id = pic.PersonId " +
"where CAST(p.Id as uniqueidentifier) = CAST('" + 
guid + 
"' as uniqueidentifier)  ", connection);
                await connection.OpenAsync();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        user.ID = reader.GetGuid(0);
                        user.DisplayName = reader.GetString(1);
                        user.UserIconPicture = new Picture()
                        {
                            Id = reader.GetGuid(2),
                            PictureType = PictureType.UserProfile,
                            Url = reader.GetString(4),
                        };
                    }
                }
            }
            return user;
        }
    }
}
