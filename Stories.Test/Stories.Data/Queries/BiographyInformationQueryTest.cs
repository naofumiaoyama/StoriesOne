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
   public class BiographyInformationQueryTest
    {
        [TestMethod]
        public async Task GetTest()
        {
            var query = new BiographyInformationQuery();
            var biography = await query.Get(Guid.Parse("969DE22D-A331-4002-840B-04C54C4E8102"));
            Assert.AreEqual(biography.Id, Guid.Parse("969DE22D-A331-4002-840B-04C54C4E8102"));
            Assert.AreEqual(biography.LivingPlace, "MandaueCity");
        }
    }
}
