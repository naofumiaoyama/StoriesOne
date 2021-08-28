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
        /// Getting PersonalInfo
        /// </summary>
        /// <param name="guid">People.Id</param>
        /// <returns></returns>
        public async Task<PersonalInfo> Get(Guid personalInfoId)
        {
            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                connection.ConnectionString = DatabaseContext.DbConnectionString;
                await connection.OpenAsync();

                var query = @"Select pi.* from PersonalInfos pi " +
                            "Where CAST(pi.Id as uniqueidentifier) = CAST('" + personalInfoId + "' as uniqueidentifier)";

                var personalInfo = connection.QueryAsync(query).Result.Select(row =>
                new PersonalInfo((Guid)row.Id,
                                 (Guid)row.PersonId,
                                 (string)row.LoginId,
                                 (string)row.EncryptedPassword,
                                 (string)row.Token,
                                 (string)row.MobileNumber,
                                 (DateTime)row.Birthdate,
                                 (Sex)row.Sex,
                                 (MaritalStatus)row.MaritalStatus,
                                 (string)row.EmailAddress1,
                                 (string)row.EmailAddress2,
                                    null)

                {

                }).FirstOrDefault();

                await connection.CloseAsync();
                
                return personalInfo;
            }
        }

        /// <summary>
        /// Getting PersonalInfo for login
        /// </summary>
        /// <param name="guid">People.Id</param>
        /// <returns></returns>
        public async Task<PersonalInfo> GetForLogin(string loginId, string encryptedPassword)
        {
            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                connection.ConnectionString = DatabaseContext.DbConnectionString;
                await connection.OpenAsync();

                var query = @"Select pi.* from PersonalInfos pi " +
                                "Where LoginId = '" + loginId + "' And EncryptedPassword = '" + encryptedPassword + "'";

                var personalInfo = connection.Query(query).Select(row =>
                new PersonalInfo((Guid)row.Id,
                                    (Guid)row.PersonId,
                                    (string)row.LoginId,
                                    (string)row.EncryptedPassword,
                                    (string)row.Token,
                                    (string)row.MobileNumber,
                                    (DateTime)row.Birthdate,
                                    (Sex)row.Sex,
                                    (MaritalStatus)row.MaritalStatus,
                                    (string)row.EmailAddress1,
                                    (string)row.EmailAddress2,
                                    null
                                    )
                {

                }).FirstOrDefault();

                await connection.CloseAsync();

                return personalInfo;

            }
            

        }
    }
}
