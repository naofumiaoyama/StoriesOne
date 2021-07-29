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
  public  class BodyQueryTest
    {
        [TestMethod]
        public async Task GetTest()
        {
            var query = new BodyQuery();
            var bodyStoryId = Guid.Parse("4EADAFCD-7585-492C-A39D-878715441048");
            var bodies = await query.Get(bodyStoryId);
            Assert.AreEqual(bodies.Count, 2);
            Assert.AreEqual(bodies[Guid.Parse("0c1c9356-5d0e-461a-a9cc-ce0d4b99126e")].BodyContent, "Action Story chapter2 aaaaaaaaaa");
        }
    }
}
