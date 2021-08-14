using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stories.Data.Queries;
using Stories.Domain.Model;

namespace Stories.Test.Stories.Data.Queries
{
    [TestClass]
    public class FriendQueryTest
    {

        [TestMethod]
        public async Task GetTest()
        {
            var query = new FriendQuery();
            var guid = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
            var friendGuid = Guid.Parse("F7A70CB7-F46D-4A94-88CD-6B0284CBE96F");
            Dictionary<Guid, User> friends = (Dictionary<Guid, User>) await query.Get(guid);
            Assert.AreEqual(friends[friendGuid].FullName, "Jenalyn Aoyama");
        }
    }
}      
