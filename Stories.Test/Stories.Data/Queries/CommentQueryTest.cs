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
  public  class CommentQueryTest
    {
        [TestMethod]
        public async Task GetTest()
        {
            var query = new CommentQuery();
            var commentPersonId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
            var comments = await query.Get(commentPersonId);
            Assert.AreEqual(comments.CommentText,"Abc");
        }
    }
}
