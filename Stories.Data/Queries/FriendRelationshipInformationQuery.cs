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
    public class FriendRelationshipInformationQuery : IFriendRelationshipInformationQuery
    {
        public async Task<FriendRelationship> Get(Guid guid)
        {
            FriendRelationship friendRelationship = new FriendRelationship();

            using (var connection = new SqlConnection("server = localhost\\MSSQLSERVER01; database = Stories; integrated security = true"))
            {
                var command = new SqlCommand(
                "Select p.Id, friend.PersonId, Friend.FriendPersonId,Friend.FriendshipDateTime from FriendRelationships Friend " +
                "INNER JOIN People p on p.Id = friend.PersonId" +
                "Where CAST(Friend.PersonId as uniqueidentifier) = CAST('" +
                guid + "' as uniqueidentifier)", connection);
                await connection.OpenAsync();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        friendRelationship.PersonId = reader.GetGuid(2);
                        friendRelationship.FriendPersonId = reader.GetGuid(3);
                        friendRelationship.FriendshipDateTime = DateTime.Now;
                    }
                }
                return friendRelationship;
            }
        }      
    }
}
