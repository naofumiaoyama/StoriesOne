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
                timeline.Id = Guid.NewGuid();
                timeline.Person = new Person();
                await timelineRepository.Add(timeline);

                //getting
                var getTimeline = await  timelineRepository.Get(timeline.Id);
                Assert.AreEqual(getTimeline.Id, timeline.Id);
                Assert.AreEqual(getTimeline.Person, getTimeline.Person);

                //Updating
                timeline.Person = new Person();
                await timelineRepository.Update(timeline);
                var updateTimeline = await timelineRepository.Get(timeline.Id);

                //Removing
                await timelineRepository.Delete(timeline);
                var resulttimeline = timelineRepository.Get(timeline.Id).Result;
                Assert.AreEqual(resulttimeline, null);
            }
        }
    }

}