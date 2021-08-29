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
            
            var guid = Guid.Parse("2b3cd24f-5802-4d74-bacd-5de67a2b2fcb");
            var address = await query.Get(guid);
            Assert.AreEqual(address.CountryCode, Domain.Model.CountryCode.Japan);
        }
    }
}      
