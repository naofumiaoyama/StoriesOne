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
                //adding
                TimelineRepository timelineRepository = new TimelineRepository(context);
                Timeline timeline = new Timeline();           
                timeline.PersonId = Guid.Parse("3A4685B0-7167-48F9-BE06-F9ACBB7E1756");
                timeline.TimelineName = "Naofumi Aoyama";
                await timelineRepository.Add(timeline);

                //getting
                var getTimeline = await  timelineRepository.Get(timeline.PersonId);                
                Assert.AreEqual(getTimeline.PersonId, getTimeline.PersonId);
                Assert.AreEqual(getTimeline.TimelineName, getTimeline.TimelineName);

                //Updating           
                timeline.TimelineName = "Jenalyn Albios";
                await timelineRepository.Update(timeline);
                var updateTimeline = await timelineRepository.Get(timeline.PersonId);

                 //Removing
                await timelineRepository.Delete(timeline);
                var resulttimeline = timelineRepository.Get(timeline.PersonId).Result;
                Assert.AreEqual(resulttimeline, null);
            }
        }
    }

} 