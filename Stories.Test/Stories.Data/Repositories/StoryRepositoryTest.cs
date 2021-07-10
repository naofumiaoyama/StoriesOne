using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stories.Data;
using Stories.Data.Entities;
using Stories.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace Stories.Test.Stories.Data.Repositories
{
    [TestClass]
  public class StoryRepositoryTest
    {
        [TestMethod]
        public async Task CRUDTest()
        {
            using (var context = new DatabaseContext())
            {
                //adding
                GenericRepository<StoryEntity>storyRepository = new GenericRepository<StoryEntity>(context);
                StoryEntity storyEntity = new StoryEntity();
                storyEntity.Id = new Guid();
                storyEntity.Title = "Titanic";
                storyEntity.AuthorPersonId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                storyEntity.Summary = "Start by a young couple meeting, falling in love and having a hard time being together";
                storyEntity.CreateDate = new DateTime(2021- 3 - 27);
                storyEntity.UpdateDate = DateTime.Today;
                storyEntity.UpdateUserId = new Guid();
                await storyRepository.Add(storyEntity);

                //Getting
                var getStoryEntity = await storyRepository.Get(storyEntity.Id);

                Assert.AreEqual(getStoryEntity.Id, storyEntity.Id);
                Assert.AreEqual(getStoryEntity.Title, storyEntity.Title);
                Assert.AreEqual(getStoryEntity.AuthorPersonId, storyEntity.AuthorPersonId);
                Assert.AreEqual(getStoryEntity.Summary, storyEntity.Summary);
                Assert.AreEqual(getStoryEntity.CreateDate, storyEntity.CreateDate);
                Assert.AreEqual(getStoryEntity.UpdateDate, storyEntity.UpdateDate);

                //Updating
                storyEntity.Title = "Lovebirds";
                storyEntity.AuthorPersonId = Guid.Parse("EEFB1E9D-4E17-43A3-A690-F374D27D36DE");
                storyEntity.Summary = "The two people who believe that love knows no age";
                storyEntity.CreateDate = new DateTime(2020 - 7 - 28);
                storyEntity.UpdateDate = DateTime.Now;
                await storyRepository.Update(storyEntity);
                var updateStoryEntity = await storyRepository.Get(storyEntity.Id);
                Assert.AreEqual(updateStoryEntity.Title, storyEntity.Title);
                Assert.AreEqual(updateStoryEntity.AuthorPersonId, storyEntity.AuthorPersonId);
                Assert.AreEqual(updateStoryEntity.Summary, storyEntity.Summary);
                Assert.AreEqual(updateStoryEntity.CreateDate, storyEntity.CreateDate);
                Assert.AreEqual(updateStoryEntity.UpdateDate, storyEntity.UpdateDate);
                Assert.AreEqual(updateStoryEntity.UpdateUserId, storyEntity.UpdateUserId);

                //Removing
              // await storyRepository.Remove(storyEntity);
              // var resultstory = storyRepository.Get(storyEntity.Id).Result;
              // Assert.AreEqual(resultstory, null);
            }
        }
    }
}
