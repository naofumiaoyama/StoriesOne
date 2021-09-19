using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Stories.Data.Queries.Interface;
using Stories.Domain.Model;


namespace Stories.Data.Queries
{
   
    public class NotificationQuery : INotificationQuery
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="notificationid"></param>
        /// <returns></returns>
        public async Task<Notification> Get(Guid notificationid)
        {
            using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                connection.ConnectionString = DatabaseContext.DbConnectionString;
                await connection.OpenAsync();

                var query = @"select ns.* from Notifications ns " +
                 "Where CAST(ns.Id as uniqueidentifier) = CAST('" + notificationid + "' as uniqueidentifier)";

                var notification = connection.QueryAsync(query).Result.Select(row =>
                new Notification((Guid)row.Id,
                     (Guid)row.DispImageId,
                     (string)row.Contents,
                     (string)row.UrlLink)
                {
                }).FirstOrDefault();

                await connection.CloseAsync();

                return notification;
            }
        }
    }
}
