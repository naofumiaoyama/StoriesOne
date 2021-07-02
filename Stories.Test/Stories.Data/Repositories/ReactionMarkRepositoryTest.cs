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
                ReactionMarkRepository reactionMarkRepository = new ReactionMarkRepository(context);
                ReactionMark reactionMark = new ReactionMark();
                reactionMark.Id = Guid.NewGuid();
                reactionMark.Url = "http://www.shortstories.com";
                reactionMark.Name = "helloworld";
                await reactionMarkRepository.Add(reactionMark);

                //Getting
                var getReactionMark = await reactionMarkRepository.Get(reactionMark.Id);

                Assert.AreEqual(getReactionMark.Url, reactionMark.Url);
                Assert.AreEqual(getReactionMark.Name, reactionMark.Name);

                //Updating
                reactionMark.Url = "http://www.short.net";
                reactionMark.Name = "Hello";
                await reactionMarkRepository.Update(reactionMark);
                var updateReactionMark = await reactionMarkRepository.Get(reactionMark.Id);
                Assert.AreEqual(updateReactionMark.Name, reactionMark.Name);

                ////Removing
               await reactionMarkRepository.Delete(reactionMark);
               var resultReactionMark = reactionMarkRepository.Get(reactionMark.Id).Result;
               Assert.AreEqual(resultReactionMark, null);
            }
        }
    }
}
