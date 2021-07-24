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
    public class PersonalInfoQuery : IPersonalInfoQuery
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="guid">People.Id</param>
        /// <returns></returns>
        public async Task<PersonalInfo> Get(Guid guid)
        {
            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                connection.ConnectionString = DatabaseContext.DbConnectionString;
                await connection.OpenAsync();

                var query = @"Select pi.* from PersonalInfos pi " +
                            "Where CAST(pi.Id as uniqueidentifier) = CAST('" + guid + "' as uniqueidentifier)";
                
                var personalInfos = await connection.QueryAsync<PersonalInfo>(query);
                
                await connection.CloseAsync();
                
                return personalInfos.FirstOrDefault();

            }
        }
    }
}
