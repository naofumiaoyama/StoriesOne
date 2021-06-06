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
    public class UserInformationQueryTest
    {

        [TestMethod]
        public async Task GetTest()
        {
            var query = new UserInformationQuery();
            var user = await query.Get(Guid.Parse("1DD10D85-AB15-41B6-936B-0BC8E439DD66"));
            Assert.AreEqual(user.ID, Guid.Parse("1DD10D85-AB15-41B6-936B-0BC8E439DD66"));
            Assert.AreEqual(user.DisplayName, "N.A");
        }
    }
}
