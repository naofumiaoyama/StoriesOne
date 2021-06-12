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
    public class PersonInformationQuery : IPersonInformationQuery
    {
        public async Task<Person> Get(Guid guid)
        {
            User user = new User();
            using (var connection = new SqlConnection("server = localhost\\MSSQLSERVER01; database = Stories; integrated security = true"))
            {
                var command = new SqlCommand("" +
            "select time.Id TimeId, time.PersonId, p.DisplayName, p.GivenName, p.FamilyName, p.SelfIntroduction, p.Password, p.LoginId from Timelines time " +
            "INNER JOIN People p on p.Id = time.PersonId " + 
            "where CAST(p.Id as uniqueidentifier) = CAST('" + guid + "' as uniqueidentifier)" , connection);
                await connection.OpenAsync();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        user.ID = reader.GetGuid(1);
                        user.DisplayName = reader.GetString(2);
                        user.GivenName = reader.GetString(3);                       
                    }
                }
                return user;
        }   }
    }
}           