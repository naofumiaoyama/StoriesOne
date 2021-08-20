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
            var commentPostId = Guid.Parse("231A90BC-72E8-4A01-8967-73EE78E0D497");
            var comments = await query.Get(commentPostId);
            Assert.AreEqual(comments[Guid.Parse("68AFFD37-1590-4EC9-9596-76A99F3AD892")].CommentText, "Abc");
            Assert.AreEqual(comments[Guid.Parse("9C886F4A-5BCE-4FEF-82AB-BF3BB922FACD")].CommentText, "def");
        }
    }
}
