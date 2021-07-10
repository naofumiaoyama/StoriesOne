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
                GenericRepository<TimelineEntity>timelineRepository = new GenericRepository<TimelineEntity>(context);
                //adding
                TimelineEntity timelineEntity = new TimelineEntity();
                timelineEntity.PersonId = Guid.Parse("F7A70CB7-F46D-4A94-88CD-6B0284CBE96F");
                timelineEntity.TimelineName = "Jenalyn Albios";
                timelineEntity.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                timelineEntity.CreateDate = DateTime.Now;
                timelineEntity.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                timelineEntity.UpdateDate = DateTime.Now;
                await timelineRepository.Add(timelineEntity);
    

                //getting
                var getTimelineEntity = await  timelineRepository.Get(timelineEntity.PersonId);                
                Assert.AreEqual(getTimelineEntity.PersonId, getTimelineEntity.PersonId);
                Assert.AreEqual(getTimelineEntity.TimelineName, getTimelineEntity.TimelineName);

                //Updating           
                timelineEntity.TimelineName = "Jenalyn Albios";
                await timelineRepository.Update(timelineEntity);
                var updateTimeline = await timelineRepository.Get(timelineEntity.PersonId);
                Assert.AreEqual(updateTimeline.TimelineName, timelineEntity.TimelineName);

                //Removing
                await timelineRepository.Remove(timelineEntity);
                var resulttimeline = timelineRepository.Get(timelineEntity.PersonId).Result;
                Assert.AreEqual(resulttimeline, null);
            }
        }
    }

} 