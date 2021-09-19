﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var characterStoryId = await query.Get(Guid.Parse("D701ACBD-97D9-437B-A949-A4CF04A33521"));
        }
    }
}
