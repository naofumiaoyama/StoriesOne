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
                GenericRepository<FriendRelationshipT> friendRelationshipRepository = new GenericRepository<FriendRelationshipT>(context);
                FriendRelationshipT friendRelationship = new FriendRelationshipT();
                friendRelationship.Id = Guid.Parse("2E4B133E-BEB5-44C6-9912-7A48CDECCC98");
                friendRelationship.PersonId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                friendRelationship.FullName = "Naofumi Aoyama";
                friendRelationship.FriendPersonId = Guid.Parse("0389C8FF-2B0F-4215-8F47-DD58C69CA17C");
                friendRelationship.FriendFullName = "Jenalyn Aoyama";
                friendRelationship.FriendshipDateTime = DateTime.Now;
                await friendRelationshipRepository.Add(friendRelationship);

                //getting
                var getFriendRelationship = await friendRelationshipRepository.Get(friendRelationship.Id);
             

                Assert.AreEqual(getFriendRelationship.Id, friendRelationship.Id);
                Assert.AreEqual(getFriendRelationship.PersonId, friendRelationship.PersonId);
                Assert.AreEqual(getFriendRelationship.FullName, friendRelationship.FullName);
                Assert.AreEqual(getFriendRelationship.FriendPersonId, friendRelationship.FriendPersonId);
                Assert.AreEqual(getFriendRelationship.FriendFullName, friendRelationship.FriendFullName);
                Assert.AreEqual(getFriendRelationship.FriendshipDateTime, friendRelationship.FriendshipDateTime);

                //updating
                friendRelationship.FullName = "Naofumi Aoyama 2";
                friendRelationship.FriendPersonId = Guid.Parse("157B7DC6-0D77-4305-A70F-3B73BA581351");
                friendRelationship.FriendFullName = "Jenalyn Aoyama 2";
                friendRelationship.FriendshipDateTime = DateTime.Today;
                await friendRelationshipRepository.Update(friendRelationship);
                var updatefriendRelationship = await friendRelationshipRepository.Get(friendRelationship.Id);
                Assert.AreEqual(updatefriendRelationship.FullName, friendRelationship.FullName);
                Assert.AreEqual(updatefriendRelationship.FriendFullName, friendRelationship.FriendFullName);
               
                //removing
                await friendRelationshipRepository.Remove(friendRelationship);
                var resultPersonalInfo = friendRelationshipRepository.Get(friendRelationship.PersonId).Result;
                Assert.AreEqual(resultPersonalInfo, null);


            }
        }
    }
}
