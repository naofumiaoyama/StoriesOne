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
   public class BodyRepositoryTest
    {
        [TestMethod]
        public async Task CRUDTest()
        {
            using (var context = new DatabaseContext())
            {
                //adding
                GenericRepository<Chapter> chapterRepository = new GenericRepository<Chapter>(context);
                Chapter chapter = new Chapter();
                chapter.Id = Guid.Parse("8fdc139c-0cf1-49f5-9e80-ec71f6c74864");
                chapter.StoryId = Guid.Parse("D701ACBD-97D9-437B-A949-A4CF04A33521");
                chapter.Number = 1;
                chapter.Content = "Story";
                await chapterRepository.Add(chapter);

                //getting
                var getBody = await chapterRepository.Get(chapter.Id);
                Assert.AreEqual(getBody.Id, chapter.Id);
                Assert.AreEqual(getBody.StoryId, chapter.StoryId);
                Assert.AreEqual(getBody.Number, chapter.Number);
                Assert.AreEqual(getBody.Content, chapter.Content);

                //updating
                chapter.StoryId = Guid.Parse("4EADAFCD-7585-492C-A39D-878715441048");
                chapter.Number = 2;
                chapter.Content = "Stories Synopsis";
                await chapterRepository.Update(chapter);
                var updatebody = await chapterRepository.Get(chapter.Id);
                Assert.AreEqual(updatebody.Id, chapter.Id);
                Assert.AreEqual(updatebody.StoryId, chapter.StoryId);
                Assert.AreEqual(updatebody.Number, chapter.Number);
                Assert.AreEqual(updatebody.Content, chapter.Content);

                //removing
                await chapterRepository.Remove(chapter);
                var resultbody = chapterRepository.Get(chapter.Id).Result;
                Assert.AreEqual(resultbody, null);
            }
        }
    }
}
