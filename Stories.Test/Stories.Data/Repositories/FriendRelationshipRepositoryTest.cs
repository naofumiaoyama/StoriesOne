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
                friendRelationship.Id = Guid.Parse("2E4B133E-BEB5-44C6-9912-7A48CDECCC98");
                friendRelationship.PersonId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                friendRelationship.FullName = "Naofumi Aoyama";
                friendRelationship.FriendPersonId = Guid.Parse("0389C8FF-2B0F-4215-8F47-DD58C69CA17C");
                friendRelationship.FriendFullName = "Jenalyn Aoyama";
                friendRelationship.FriendshipDateTime = DateTime.Now;
                await friendRelationshipRepository.Add(friendRelationship);

                //getting
                var getfriendRelationship = await friendRelationshipRepository.Get(friendRelationship.Id);
             

                Assert.AreEqual(getfriendRelationship.Id, friendRelationship.Id);
                Assert.AreEqual(getfriendRelationship.PersonId, friendRelationship.PersonId);
                Assert.AreEqual(getfriendRelationship.FullName, friendRelationship.FullName);
                Assert.AreEqual(getfriendRelationship.FriendPersonId, friendRelationship.FriendPersonId);
                Assert.AreEqual(getfriendRelationship.FriendFullName, friendRelationship.FriendFullName);
                Assert.AreEqual(getfriendRelationship.FriendshipDateTime, friendRelationship.FriendshipDateTime);

                //updating
                friendRelationship.FullName = "Naofumi Aoyama 2";
                friendRelationship.FriendPersonId = Guid.Parse("157B7DC6-0D77-4305-A70F-3B73BA581351");
                friendRelationship.FriendFullName = "Jenalyn Aoyama 2";
                friendRelationship.FriendshipDateTime = DateTime.Today;
                await friendRelationshipRepository.Update(friendRelationship);
                var updateFriendRelationship = await friendRelationshipRepository.Get(friendRelationship.Id);
                Assert.AreEqual(updateFriendRelationship.FullName, friendRelationship.FullName);
                Assert.AreEqual(updateFriendRelationship.FriendFullName, friendRelationship.FriendFullName);
               
                //removing
                await friendRelationshipRepository.Remove(friendRelationship);
                var resultPersonalInfo = friendRelationshipRepository.Get(friendRelationship.PersonId).Result;
                Assert.AreEqual(resultPersonalInfo, null);


            }
        }
    }
}
