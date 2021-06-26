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
                TimelineRepository timelineRepository = new TimelineRepository(context);
                Timeline timeline = new Timeline();
                timeline.PersonId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                timeline.TimelineName = "Naofumi Aoyama";
                await timelineRepository.Add(timeline);

                Timeline timeline2 = new Timeline();
                timeline2.PersonId = Guid.Parse("F7A70CB7-F46D-4A94-88CD-6B0284CBE96F");
                timeline2.TimelineName = "Jenalyn Albios";
                await timelineRepository.Add(timeline2);
            }
        }

        public async Task DeleteData()
        {
            using (var context = new DatabaseContext())
            {
                TimelineRepository timelineRepository = new TimelineRepository(context);
                var timeline1 = timelineRepository.Get(Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F")).Result;
                if (timeline1 != null) { await timelineRepository.Delete(timeline1); }

                var timeline2 = timelineRepository.Get(Guid.Parse("F7A70CB7-F46D-4A94-88CD-6B0284CBE96F")).Result;
                if (timeline2 != null)
                {
                    await timelineRepository.Delete(timeline2);
                }
            }
        }

    }
}  