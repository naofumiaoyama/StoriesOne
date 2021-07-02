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
    public class FriendQueryTest
    {

        [TestMethod]
        public async Task GetTest()
        {
            var query = new FriendQuery();
            var friends = await query.Get(Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F"));
        }
    }
}      
