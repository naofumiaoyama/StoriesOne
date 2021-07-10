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
    public class friendRelationshipRepositoryTest
    {

        [TestMethod]
        public async Task CRUDTest()
        {
            using (var context = new DatabaseContext())
            {
                //adding
                GenericRepository<FriendRelationshipEntity> friendRelationshipRepository = new GenericRepository<FriendRelationshipEntity>(context);
                FriendRelationshipEntity friendRelationshipEntity = new FriendRelationshipEntity();
                friendRelationshipEntity.Id = Guid.Parse("2E4B133E-BEB5-44C6-9912-7A48CDECCC98");
                friendRelationshipEntity.PersonId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                friendRelationshipEntity.FullName = "Naofumi Aoyama";
                friendRelationshipEntity.FriendPersonId = Guid.Parse("0389C8FF-2B0F-4215-8F47-DD58C69CA17C");
                friendRelationshipEntity.FriendFullName = "Jenalyn Aoyama";
                friendRelationshipEntity.FriendshipDateTime = DateTime.Now;
                await friendRelationshipRepository.Add(friendRelationshipEntity);

                //getting
                var getFriendRelationshipEntity = await friendRelationshipRepository.Get(friendRelationshipEntity.Id);
             

                Assert.AreEqual(getFriendRelationshipEntity.Id, friendRelationshipEntity.Id);
                Assert.AreEqual(getFriendRelationshipEntity.PersonId, friendRelationshipEntity.PersonId);
                Assert.AreEqual(getFriendRelationshipEntity.FullName, friendRelationshipEntity.FullName);
                Assert.AreEqual(getFriendRelationshipEntity.FriendPersonId, friendRelationshipEntity.FriendPersonId);
                Assert.AreEqual(getFriendRelationshipEntity.FriendFullName, friendRelationshipEntity.FriendFullName);
                Assert.AreEqual(getFriendRelationshipEntity.FriendshipDateTime, friendRelationshipEntity.FriendshipDateTime);

                //updating
                friendRelationshipEntity.FullName = "Naofumi Aoyama 2";
                friendRelationshipEntity.FriendPersonId = Guid.Parse("157B7DC6-0D77-4305-A70F-3B73BA581351");
                friendRelationshipEntity.FriendFullName = "Jenalyn Aoyama 2";
                friendRelationshipEntity.FriendshipDateTime = DateTime.Today;
                await friendRelationshipRepository.Update(friendRelationshipEntity);
                var updatefriendRelationshipEntity = await friendRelationshipRepository.Get(friendRelationshipEntity.Id);
                Assert.AreEqual(updatefriendRelationshipEntity.FullName, friendRelationshipEntity.FullName);
                Assert.AreEqual(updatefriendRelationshipEntity.FriendFullName, friendRelationshipEntity.FriendFullName);
               
                //removing
                await friendRelationshipRepository.Remove(friendRelationshipEntity);
                var resultPersonalInfo = friendRelationshipRepository.Get(friendRelationshipEntity.PersonId).Result;
                Assert.AreEqual(resultPersonalInfo, null);


            }
        }
    }
}
