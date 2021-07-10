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
  public class StoryQueryTest
    {
        [TestMethod]
        public async Task GetTest()
        {
            var query = new StoryQuery();
            
            var storyPersonGuid = Guid.Parse("EEFB1E9D-4E17-43A3-A690-F374D27D36DE");
            var storyId = Guid.Parse("4EADAFCD-7585-492C-A39D-878715441048");
            var stories = await query.Get(storyPersonGuid);
            Assert.AreEqual(stories[storyId].Id, storyId);
        }
    }
}
 