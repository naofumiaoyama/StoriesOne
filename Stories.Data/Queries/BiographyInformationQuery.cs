using Stories.Data.Queries.Interface;
using Stories.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Queries
{
    public class BiographyInformationQuery : IBiographyInformationQuery
    {
        public async Task<Biography> Get(Guid guid)
        {
            Biography biography = new Biography();
            using (var connection = new SqlConnection("server = localhost\\MSSQLSERVER01; database = Stories; integrated security = true"))
            {
                var command = new SqlCommand("" +
               " select p.Id personId, b.Id, b.PersonId, b.LivingPlace, b.Occupation, b.MaritalStatus from Biographies b" +
               "INNER JOIN  People p  on  p.Id = b.PersonId" +
                "where CAST(b.Id as uniqueidentifier) = CAST('" + guid + "' as uniqueidentifier)", connection);
                await connection.OpenAsync();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        biography.Id = reader.GetGuid(1);
                        biography.LivingPlace = reader.GetString(3);
                        biography.Occupation = reader.GetString(4);
                        biography.MaritalStatus = (MaritalStatus)reader.GetInt32(5);
                       
                    }
                }
            }
            return biography;
        }


    }
}
  