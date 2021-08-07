using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stories.Data.Entities;
using Stories.Data.Repositories;


namespace Stories.Data.InitialData
{
    public class TimelineData
    {
        public async Task MakeData()
        {
            using (var context = new DatabaseContext())
            {
                GenericRepository<Timeline>timelineRepository = new GenericRepository<Timeline>(context);
                Timeline timeline = new Timeline();
                timeline.Id = Guid.Parse("09604DDD-D01A-4307-BD5D-908594216904");
                timeline.OwnerPersonId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                timeline.TimelineName = "Naofumi Aoyama";
                timeline.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                timeline.CreateDate = DateTime.Now;
                timeline.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                timeline.UpdateDate = DateTime.Now;
                await timelineRepository.Add(timeline);

                Timeline timeline2 = new Timeline();
                timeline2.Id = Guid.Parse("C1F76AAB-C27C-42C0-9BDB-1DE9EC182B0B");
                timeline2.OwnerPersonId = Guid.Parse("0389C8FF-2B0F-4215-8F47-DD58C69CA17C");
                timeline2.TimelineName = "Chisumi Aoyama";
                timeline2.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                timeline2.CreateDate = DateTime.Now;
                timeline2.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                timeline2.UpdateDate = DateTime.Now;
                await timelineRepository.Add(timeline2);


            }
        }

        public async Task DeleteData()
        {
            using (var context = new DatabaseContext())
            {
                GenericRepository<Timeline> timelineRepository = new GenericRepository<Timeline>(context);
                var timeline1 = timelineRepository.Get(Guid.Parse("09604DDD-D01A-4307-BD5D-908594216904")).Result;
                if (timeline1 != null) { await timelineRepository.Remove(timeline1); }

                var timeline2 = timelineRepository.Get(Guid.Parse("C1F76AAB-C27C-42C0-9BDB-1DE9EC182B0B")).Result;
                if (timeline2 != null) { await timelineRepository.Remove(timeline2); }
            }
        }

    }
}  