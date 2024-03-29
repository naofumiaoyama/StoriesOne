﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
                GenericRepository<Story>storyRepository = new GenericRepository<Story>(context);
                Story story = new Story();
                story.Id = Guid.Parse("06afba69-53be-409c-bebd-ffadafb4524b");
                story.PersonId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                story.Title = "Titanic";
                story.GenreId = Guid.Parse("A130CB16-4349-48DB-9E10-764974E4102D");
                story.Summary = "Start by a young couple meeting, falling in love and having a hard time being together";
                story.CreateDate = new DateTime(2021- 3 - 27);
                story.UpdateDate = DateTime.Today;
                story.UpdateUserId = new Guid();
                await storyRepository.Add(story);

                //Getting
                var getStory = await storyRepository.Get(story.Id);

                Assert.AreEqual(getStory.Id, story.Id);
                Assert.AreEqual(getStory.Title, story.Title);
                Assert.AreEqual(getStory.Summary, story.Summary);
                Assert.AreEqual(getStory.CreateDate, story.CreateDate);
                Assert.AreEqual(getStory.UpdateDate, story.UpdateDate);

                //Updating
                story.Title = "Lovebirds";
                story.Summary = "The two people who believe that love knows no age";
                story.CreateDate = new DateTime(2020 - 7 - 28);
                story.UpdateDate = DateTime.Now;
                await storyRepository.Update(story);
                var updateStory = await storyRepository.Get(story.Id);
                Assert.AreEqual(updateStory.Title, story.Title);
                Assert.AreEqual(updateStory.Summary, story.Summary);
                Assert.AreEqual(updateStory.CreateDate, story.CreateDate);
                Assert.AreEqual(updateStory.UpdateDate, story.UpdateDate);
                Assert.AreEqual(updateStory.UpdateUserId, story.UpdateUserId);

                //Removing
                await storyRepository.Remove(story);
                var resultstory = storyRepository.Get(story.Id).Result;
                Assert.AreEqual(resultstory, null);
            }
        }
    }
}
