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

    public class LoginQuery : ILoginQuery
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="guid">People.Id</param>
        /// <returns></returns>
        public async Task<PersonalInfo> Get(string loginId, string password)
        {
            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                connection.ConnectionString = DatabaseContext.DbConnectionString;
                await connection.OpenAsync();

                var query = @"Select pi.* from PersonalInfos pi " +
                             "Where LoginId = " + loginId + "And Password = " + password;

                var personalInfos = await connection.QueryAsync<PersonalInfo>(query);

                await connection.CloseAsync();

                return personalInfos.FirstOrDefault();

            }
        }

    }
}
