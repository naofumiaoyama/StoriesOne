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
                ReactionMarkEntity reactionMarkEntity = new ReactionMarkEntity();
                reactionMarkEntity.Id = Guid.NewGuid();
                reactionMarkEntity.Url = "http://www.shortstories.com";
                reactionMarkEntity.Name = "helloworld";
                await reactionMarkRepository.Add(reactionMarkEntity);

                //Getting
                var getReactionMark = await reactionMarkRepository.Get(reactionMarkEntity.Id);

                Assert.AreEqual(getReactionMark.Url, reactionMarkEntity.Url);
                Assert.AreEqual(getReactionMark.Name, reactionMarkEntity.Name);

                //Updating
                reactionMarkEntity.Url = "http://www.short.net";
                reactionMarkEntity.Name = "Hello";
                await reactionMarkRepository.Update(reactionMarkEntity);
                var updateReactionMark = await reactionMarkRepository.Get(reactionMarkEntity.Id);
                Assert.AreEqual(updateReactionMark.Name, reactionMarkEntity.Name);

                ////Removing
               await reactionMarkRepository.Remove(reactionMarkEntity);
               var resultReactionMark = reactionMarkRepository.Get(reactionMarkEntity.Id).Result;
               Assert.AreEqual(resultReactionMark, null);
            }
        }
    }
}
