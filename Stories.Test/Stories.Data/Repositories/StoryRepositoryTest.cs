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
                StoryRepository storyRepository = new StoryRepository(context);
                Story story = new Story();
                story.Id = Guid.NewGuid();
                story.Title = "Titanic";
                story.AuthorPersonId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                story.Summary = "Start by a young couple meeting, falling in love and having a hard time being together";
                story.CreateDate = new DateTime(2021- 3 - 27);
                story.UpdateDate = DateTime.Today;
                await storyRepository.Add(story);

                //Getting
                var getStory = await storyRepository.Get(story.Id);

                Assert.AreEqual(getStory.Id, story.Id);
                Assert.AreEqual(getStory.Title, story.Title);
                Assert.AreEqual(getStory.AuthorPersonId, story.AuthorPersonId);
                Assert.AreEqual(getStory.Summary, story.Summary);
                Assert.AreEqual(getStory.CreateDate, story.CreateDate);
                Assert.AreEqual(getStory.UpdateDate, story.UpdateDate);

                //Updating
                story.Title = "Lovebirds";
              
                await storyRepository.Update(story);
                var updateStory = await storyRepository.Get(story.Id);
                Assert.AreEqual(updateStory.Title, story.Title);
                Assert.AreEqual(updateStory.AuthorPersonId, story.AuthorPersonId);

                //Removing
               await storyRepository.Delete(story);
               var resultstory = storyRepository.Get(story.Id).Result;
               Assert.AreEqual(resultstory, null);

            }
        }
    }
}
