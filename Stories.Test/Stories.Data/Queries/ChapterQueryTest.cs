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
  public  class ChapterQueryTest
    {
        [TestMethod]
        public async Task GetTest()
        {
            var query = new ChapterQuery();
            var storyId = Guid.Parse("39F9BD09-3589-4739-97F5-6C8912AC18E7");
            var chapters = await query.Get(storyId);
      //      Assert.AreEqual(chapters.Count, 2);
        //    Assert.AreEqual(chapters[Guid.Parse("0c1c9356-5d0e-461a-a9cc-ce0d4b99126e")].Content, "Action Story chapter2 aaaaaaaaaa");
        }
    }
}
