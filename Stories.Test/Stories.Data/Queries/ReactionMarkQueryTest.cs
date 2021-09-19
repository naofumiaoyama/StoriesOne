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
  public class ReactionMarkQueryTest
    {
        [TestMethod]
        public async Task GetTest()
        {
            var query = new ReactionMarkQuery();
            var reactionMarkPostId = Guid.Parse("231A90BC-72E8-4A01-8967-73EE78E0D497");
            var reactionMarks = await query.Get(reactionMarkPostId);          
        }
  }
}
