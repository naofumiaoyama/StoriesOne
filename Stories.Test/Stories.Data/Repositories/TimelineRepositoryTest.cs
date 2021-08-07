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
   public class TimelineRepositoryTest
    {
        [TestMethod]
        public async Task CRUDTest()
        {
            using(var context = new DatabaseContext())
            {
                GenericRepository<Timeline>timelineRepository = new GenericRepository<Timeline>(context);
                //adding
                Timeline timeline = new Timeline();
                timeline.OwnerPersonId = Guid.Parse("F7A70CB7-F46D-4A94-88CD-6B0284CBE96F");
                timeline.TimelineName = "Jenalyn Albios";
                timeline.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                timeline.CreateDate = DateTime.Now;
                timeline.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                timeline.UpdateDate = DateTime.Now;
                await timelineRepository.Add(timeline);
    

                //getting
                var getTimeline = await  timelineRepository.Get(timeline.Id);                
                Assert.AreEqual(getTimeline.OwnerPersonId, getTimeline.OwnerPersonId);
                Assert.AreEqual(getTimeline.TimelineName, getTimeline.TimelineName);

                //Updating           
                timeline.TimelineName = "Jenalyn Albios";
                await timelineRepository.Update(timeline);
                var updateTimeline = await timelineRepository.Get(timeline.Id);
                Assert.AreEqual(updateTimeline.TimelineName, timeline.TimelineName);

                //Removing
                await timelineRepository.Remove(timeline);
                var resulttimeline = timelineRepository.Get(timeline.Id).Result;
                Assert.AreEqual(resulttimeline, null);
            }
        }
    }

} 