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
                GenericRepository<BodyT> bodyRepository = new GenericRepository<BodyT>(context);
                BodyT body = new BodyT();
                body.Id = Guid.Parse("8fdc139c-0cf1-49f5-9e80-ec71f6c74864");
                body.StoryId = Guid.Parse("D701ACBD-97D9-437B-A949-A4CF04A33521");
                body.ChapterNumber = 1;
                body.BodyContent = "Story";
                await bodyRepository.Add(body);

                //getting
                var getBody = await bodyRepository.Get(body.Id);
                Assert.AreEqual(getBody.Id, body.Id);
                Assert.AreEqual(getBody.StoryId, body.StoryId);
                Assert.AreEqual(getBody.ChapterNumber, body.ChapterNumber);
                Assert.AreEqual(getBody.BodyContent, body.BodyContent);

                //updating
                body.StoryId = Guid.Parse("4EADAFCD-7585-492C-A39D-878715441048");
                body.ChapterNumber = 2;
                body.BodyContent = "Stories Synopsis";
                await bodyRepository.Update(body);
                var updatebody = await bodyRepository.Get(body.Id);
                Assert.AreEqual(updatebody.Id, body.Id);
                Assert.AreEqual(updatebody.StoryId, body.StoryId);
                Assert.AreEqual(updatebody.ChapterNumber, body.ChapterNumber);
                Assert.AreEqual(updatebody.BodyContent, body.BodyContent);

                //removing
                await bodyRepository.Remove(body);
                var resultbody = bodyRepository.Get(body.Id).Result;
                Assert.AreEqual(resultbody, null);
            }
        }
    }
}
