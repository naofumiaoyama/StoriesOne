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
    public class CharacterQueryTest
    {
        [TestMethod]
        public async Task GetTest()
        {
            var query = new CharacterQuery();

            var characters = await query.Get(Guid.Parse("D701ACBD-97D9-437B-A949-A4CF04A33521"));
       
            Assert.AreEqual(characters[Guid.Parse("01A6D854-B023-4579-805D-85DCAD1347CA")].Id, Guid.Parse("01A6D854-B023-4579-805D-85DCAD1347CA"));
            Assert.AreEqual(characters[Guid.Parse("01A6D854-B023-4579-805D-85DCAD1347CA")].Name, "Romeo");
            Assert.AreEqual(characters[Guid.Parse("01A6D854-B023-4579-805D-85DCAD1347CA")].Content, "Montague family member");

            Assert.AreEqual(characters[Guid.Parse("EF1136E2-F7EE-480E-8362-34043D147372")].Id, Guid.Parse("EF1136E2-F7EE-480E-8362-34043D147372"));
            Assert.AreEqual(characters[Guid.Parse("EF1136E2-F7EE-480E-8362-34043D147372")].Name, "Juliet");
            Assert.AreEqual(characters[Guid.Parse("EF1136E2-F7EE-480E-8362-34043D147372")].Content, "Capulet family member");
        }
    }
}
