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
   public class GenreQueryTest
    {
        [TestMethod]
        public async Task GetTest()
        {

            var query = new GenreQuery();
            var genreId = Guid.Parse("1D675D51-9AB5-4B50-9DCF-1E0DDED73625");
            var genre =  await query.Get(genreId);
            Assert.AreEqual(genre.Id, Guid.Parse("1D675D51-9AB5-4B50-9DCF-1E0DDED73625"));
        }
    }
}
