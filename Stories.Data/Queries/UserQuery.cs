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
        /// Getting User by Id
        /// </summary>
        /// <param name="guid">People.Id</param>
        /// <returns></returns>
        public async Task<User> Get(Guid id)
        {
            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                connection.ConnectionString = DatabaseContext.DbConnectionString;
                await connection.OpenAsync();

                var query = @"Select pe.* from People pe " +
                            "Where CAST(pe.Id as uniqueidentifier) = CAST('" + id + "' as uniqueidentifier)";

                var user = connection.QueryAsync(query).Result.Select(row =>
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
                         null,null,null)
                {
                }).FirstOrDefault();

                await connection.CloseAsync();
                
                return user;

            }
        }

        public async Task<User> GetByLoginIdAndPassword(string loginId, string encryptedPassword)
        {
            PersonalInfoQuery personalInfoQuery = new PersonalInfoQuery();
            var personalInfo = personalInfoQuery.GetForLogin(loginId, encryptedPassword).Result;

            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                connection.ConnectionString = DatabaseContext.DbConnectionString;
                await connection.OpenAsync();

                var query = @"Select pe.* from People pe " +
                            "Where CAST(pe.Id as uniqueidentifier) = CAST('" + personalInfo.PersonId + "' as uniqueidentifier)";

                var user = connection.QueryAsync(query).Result.Select(row =>
                 new User((Guid)row.Id,
                         (string)row.FirstName,
                         (string)row.LastName,
                         (string)row.NickName,
                         personalInfo,
                         (PersonType)row.PersonType,
                         (string)row.DisplayName,
                         (string)row.SelfIntroduction,
                         (string)row.LivingPlace,
                         (string)row.Occupation,
                         null, null, null)
                 {
                 }).FirstOrDefault();

                await connection.CloseAsync();
                
                return user;

            }
        }
    }
}
