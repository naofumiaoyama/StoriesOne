using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stories.Data.Queries;

namespace Stories.Test.Stories.Data.Queries
{
    [TestClass]
    public class AuthenticateApplicationTest
    {
        [TestMethod]
        public async Task GetTest()
        {
            var query = new UserQuery();
            var user = await query.Get(Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F"));
            Assert.AreEqual(user.Id, Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F"));
            Assert.AreEqual(user.FullName, "Naofumi Aoyama");
            Assert.AreEqual(user.DisplayName, "N.A");
            //Assert.AreEqual(user.Timeline.TimelineName, "Naofumi Aoyama");
        }
    }
}      
