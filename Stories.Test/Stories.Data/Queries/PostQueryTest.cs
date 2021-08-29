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
    public class PostQueryTest
    {

        [TestMethod]
        public async Task GetTest()
        {
            var query = new PostQuery();
            
            var postGuid = Guid.Parse("231A90BC-72E8-4A01-8967-73EE78E0D497");
            var post = await query.Get(postGuid);
            Assert.AreEqual(post.Title, "Hello");
        }
    }
}      
