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
    public class PersonInformationQueryTest
    {
        [TestMethod]
        public async Task GetTest()
        {
            var query = new PersonInformationQuery();
            var user = await query.Get(Guid.Parse("910811E7-EB50-4E4B-9BED-842C9E4CDB8D"));
            Assert.AreEqual(user.ID, Guid.Parse("910811E7-EB50-4E4B-9BED-842C9E4CDB8D"));
            Assert.AreEqual(user.GivenName, "Jenalyn");
        }
    }
}
