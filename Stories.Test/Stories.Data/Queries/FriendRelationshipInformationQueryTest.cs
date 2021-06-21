using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stories.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Test.Stories.Data.Queries
{
    [TestClass]
    public class FriendRelationshipInformationQueryTest
    {
        [TestMethod]
        public async Task GetTest()
        {
            var query = new FriendRelationshipInformationQuery();
            var friendRelationship = await query.Get(Guid.Parse("B87DD83A-7F89-4AD0-BB4E-E94518F8A677"));
            Assert.AreEqual(friendRelationship.PersonId, Guid.Parse("B87DD83A-7F89-4AD0-BB4E-E94518F8A677"));
            Assert.AreEqual(friendRelationship.FriendshipDateTime, "Now");
        }
    }
}
