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
            var genreId = Guid.Parse("A130CB16-4349-48DB-9E10-764974E4102D");
            var genre =  await query.Get(genreId);
            Assert.AreEqual(genre.Id, Guid.Parse("A130CB16-4349-48DB-9E10-764974E4102D"));
        }
    }
}
