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
                GenericRepository<FriendRelationship>friendRelationshipRepository = new GenericRepository<FriendRelationship>(context);
                FriendRelationship friendRelationship = new FriendRelationship();
                friendRelationship.PersonId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                friendRelationship.FullName = "Naofumi Aoyama";
                friendRelationship.FriendPersonId = Guid.Parse("F7A70CB7-F46D-4A94-88CD-6B0284CBE96F");
                friendRelationship.FriendFullName = "Jenalyn Aoyama";
                friendRelationship.FriendshipDateTime = DateTime.Now;
                friendRelationship.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                friendRelationship.CreateDate = DateTime.Now;
                friendRelationship.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                friendRelationship.UpdateDate = DateTime.Now;
                await friendRelationshipRepository.Add(friendRelationship);

                FriendRelationship friendRelationship2 = new FriendRelationship();
                friendRelationship2.PersonId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                friendRelationship2.FullName = "Shigeyoshi Aoyama";
                friendRelationship2.FriendPersonId = Guid.Parse("0389C8FF-2B0F-4215-8F47-DD58C69CA17C");
                friendRelationship2.FriendFullName = "Chisumi Aoyama";
                friendRelationship2.CreateDate = DateTime.Now;
                friendRelationship2.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                friendRelationship2.UpdateDate = DateTime.Now;
                await friendRelationshipRepository.Add(friendRelationship2);

                FriendRelationship friendRelationship3 = new FriendRelationship();
                friendRelationship3.PersonId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                friendRelationship3.FullName = "Toya Arai";
                friendRelationship3.FriendPersonId = Guid.Parse("35289062-e681-4ac5-ad9c-24700f967bfb");
                friendRelationship3.FriendFullName = "Homare Sawa";
                friendRelationship3.CreateDate = DateTime.Now;
                friendRelationship3.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                friendRelationship3.UpdateDate = DateTime.Now;
                await friendRelationshipRepository.Add(friendRelationship3);
            }
        }

        public async Task DeleteData()
        {
            using (var context = new DatabaseContext())
            {
                GenericRepository<FriendRelationship> friendRelationshipRepository = new GenericRepository<FriendRelationship>(context);
                var friendRelationship1 = friendRelationshipRepository.Get(Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F")).Result;
                if (friendRelationship1 != null) { await friendRelationshipRepository.Remove(friendRelationship1); }

                var friendRelationship2 = friendRelationshipRepository.Get(Guid.Parse("8241FD67-2A46-45A9-B64D-42D788B71A65")).Result;
                if (friendRelationship2 != null) { await friendRelationshipRepository.Remove(friendRelationship2); }

                var friendRelationship3 = friendRelationshipRepository.Get(Guid.Parse("35289062-e681-4ac5-ad9c-24700f967bfb")).Result;
                if (friendRelationship3 != null) { await friendRelationshipRepository.Remove(friendRelationship3); }
            }
        }
    }
}
