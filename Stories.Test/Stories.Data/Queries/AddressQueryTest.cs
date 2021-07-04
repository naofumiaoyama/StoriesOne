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
    public class AddressQueryTest
    {

        [TestMethod]
        public async Task GetTest()
        {
            var query = new AddressQuery();
            var guid = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
            var addressGuid = Guid.Parse("4487058c-0c80-4655-8fc6-dfda0b1b1563");
            var addresses = await query.Get(guid);
            Assert.AreEqual(addresses[addressGuid].CountryCode, "81");
        }
    }
}      
