using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stories.Data;
using Stories.Data.Entities;
using Stories.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Test.Stories.Data.Repositories
{
    [TestClass]
    public class FriendRelationshipRepositoryTest
    {
        [TestMethod]
        public async Task CRUDTest()
        {
            using (var context = new DatabaseContext())
            {
                //adding
                FriendRelationshipRepository friendRelationshipRepository = new FriendRelationshipRepository(context);
                FriendRelationship friendRelationship = new FriendRelationship();
                friendRelationship.PersonId = Guid.Parse("B87DD83A-7F89-4AD0-BB4E-E94518F8A677");
                friendRelationship.FullName = "Angelina Jolie";
                friendRelationship.FriendPersonId = Guid.Parse("4487058C-0C80-4655-8FC6-DFDA0B1B1563");
                friendRelationship.FriendFullName = "Taylor Swift";
                friendRelationship.FriendshipDateTime = DateTime.Now;
                await friendRelationshipRepository.Add(friendRelationship);

                //getting
                var getfriendrelationship = await friendRelationshipRepository.Get(friendRelationship.PersonId);

                Assert.AreEqual(getfriendrelationship.PersonId, friendRelationship.PersonId);
                Assert.AreEqual(getfriendrelationship.FullName, friendRelationship.FullName);
                Assert.AreEqual(getfriendrelationship.FriendPersonId, friendRelationship.FriendPersonId);
                Assert.AreEqual(getfriendrelationship.FriendFullName, friendRelationship.FriendFullName);
                Assert.AreEqual(getfriendrelationship.FriendshipDateTime, friendRelationship.FriendshipDateTime);

                //updating
                friendRelationship.PersonId = Guid.Parse("18923966-65CB-4EFE-8B07-00473476C13D");
                friendRelationship.FullName = "Gal Gadot";
                friendRelationship.FriendPersonId = Guid.Parse("157B7DC6-0D77-4305-A70F-3B73BA581351");
                friendRelationship.FriendFullName = "Selena Gomez";
                await friendRelationshipRepository.Update(friendRelationship);
                var updateFriendRelationship = await friendRelationshipRepository.Get(friendRelationship.PersonId);
                Assert.AreEqual(updateFriendRelationship.PersonId, friendRelationship.PersonId);

                // ////removing
                //await friendRelationshipRepository.Remove(friendRelationship);
                //var resultFriendRelationship = friendRelationshipRepository.Get(friendRelationship.PersonId).Result;
               // Assert.AreEqual(resultFriendRelationship, null);
            }
        }
    }
}