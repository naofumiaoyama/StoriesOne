using Stories.Data.Entities;
using Stories.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.InitialData
{
  public class FriendRelationshipData
    {
        public async Task MakeData()
        {
            using (var context = new DatabaseContext())
            {
                FriendRelationshipRepository friendRelationshipRepository = new FriendRelationshipRepository(context);
                FriendRelationship friendRelationship = new FriendRelationship();
                friendRelationship.PersonId = Guid.Parse("B87DD83A-7F89-4AD0-BB4E-E94518F8A677");
                friendRelationship.FullName = "Angelina Jolie";
                friendRelationship.FriendPersonId = Guid.Parse("4487058C-0C80-4655-8FC6-DFDA0B1B1563");
                friendRelationship.FriendFullName = "Taylor Swift";
                friendRelationship.FriendshipDateTime = DateTime.Now;
                await friendRelationshipRepository.Add(friendRelationship);

                FriendRelationship friendRelationship2 = new FriendRelationship();
                friendRelationship2.PersonId = Guid.Parse("8241FD67-2A46-45A9-B64D-42D788B71A65");
                friendRelationship2.FullName = "Gal Gadot";
                friendRelationship2.FriendPersonId = Guid.Parse("34AFAE61-FBBA-40FB-B2FF-4704CBC6A6B0");
                friendRelationship2.FriendFullName = "Selena Gomez";
                await friendRelationshipRepository.Add(friendRelationship2);
            }
        }

        public async Task DeleteData()
        {
            using (var context = new DatabaseContext())
            {
                FriendRelationshipRepository friendRelationshipRepository = new FriendRelationshipRepository(context);
                var friendRelationship1 = friendRelationshipRepository.Get(Guid.Parse("B87DD83A-7F89-4AD0-BB4E-E94518F8A677")).Result;
                if (friendRelationship1 != null) { await friendRelationshipRepository.Remove(friendRelationship1); }

                var friendRelationship2 = friendRelationshipRepository.Get(Guid.Parse("8241FD67-2A46-45A9-B64D-42D788B71A65")).Result;
                if (friendRelationship2 != null) { await friendRelationshipRepository.Remove(friendRelationship2); }
            }
        }
    }
}
