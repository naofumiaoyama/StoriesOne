using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stories.Data;
using Stories.Data.Entities;
using Stories.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Test.Stories.Data.Repositories
{
    [TestClass]
   public class ReactionMarkRepositoryTest
    {
        [TestMethod]
        public async Task CRUDTest()
        {
            using (var context = new DatabaseContext())
            {
                //Adding
                GenericRepository<ReactionMarkEntity>reactionMarkRepository = new GenericRepository<ReactionMarkEntity>(context);
                ReactionMarkEntity reactionMark = new ReactionMarkEntity();
                reactionMark.Id = Guid.Parse("347157AA-A162-48A5-94C4-87A023A77A3A");
                reactionMark.Url = "http://www.shortstories.com";
                reactionMark.Name = "helloworld";
                await reactionMarkRepository.Add(reactionMark);

                //Getting
                var getReactionMark = await reactionMarkRepository.Get(reactionMark.Id);
                Assert.AreEqual(getReactionMark.Id, reactionMark.Id);
                Assert.AreEqual(getReactionMark.Url, reactionMark.Url);
                Assert.AreEqual(getReactionMark.Name, reactionMark.Name);

                //Updating
                reactionMark.Url = "http://www.short.net";
                reactionMark.Name = "Hello";
                await reactionMarkRepository.Update(reactionMark);
                var updateReactionMark = await reactionMarkRepository.Get(reactionMark.Id);
                Assert.AreEqual(updateReactionMark.Name, reactionMark.Name);

                //Removing
                await reactionMarkRepository.Remove(reactionMark);
                var resultReactionMark = reactionMarkRepository.Get(reactionMark.Id).Result;
                Assert.AreEqual(resultReactionMark, null);
            }
        }
    }
}
