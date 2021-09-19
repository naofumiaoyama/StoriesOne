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
            
            var storyPersonGuid = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
            var storyId = Guid.Parse("D701ACBD-97D9-437B-A949-A4CF04A33521");
            var stories = await query.Get(storyPersonGuid);
            Assert.AreEqual(stories[storyId].Id, storyId);
        }
    }
}
 