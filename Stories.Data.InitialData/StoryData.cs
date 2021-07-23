using Stories.Data.Entities;
using Stories.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.InitialData
{
  public  class StoryData
    {
        public async Task MakeData()
        {
            using (var context = new DatabaseContext())
            {
                GenericRepository<Story>storyRepository = new GenericRepository<Story>(context);
                Story story = new Story();
                story.Id = Guid.Parse("D701ACBD-97D9-437B-A949-A4CF04A33521");
                story.Title = "Titanic";
                story.AuthorPersonId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                story.Summary = "Start by a young couple meeting, falling in love and having a hard time being together";
                story.CreateDate = new DateTime(2021 - 3 - 27);
                story.UpdateDate = DateTime.Today;
                story.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                story.CreateDate = DateTime.Now;
                story.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                story.UpdateDate = DateTime.Now;
                await storyRepository.Add(story);

                Story story2 = new Story();
                story2.Id = Guid.Parse("4EADAFCD-7585-492C-A39D-878715441048");
                story2.Title = "Lovebirds";
                story2.AuthorPersonId = Guid.Parse("EEFB1E9D-4E17-43A3-A690-F374D27D36DE");
                story2.Summary = "The two people who believe that love knows no age";
                story2.CreateDate = new DateTime(2020 - 7 - 28);
                story2.UpdateDate = DateTime.Now;
                story2.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                story2.CreateDate = DateTime.Now;
                story2.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                story2.UpdateDate = DateTime.Now;
                await storyRepository.Add(story2);

            }
        }

        public async Task DeleteData()
        {
            using (var context = new DatabaseContext())
            {

                GenericRepository<Story> storyRepository = new GenericRepository<Story>(context);
                var story1 = storyRepository.Get(Guid.Parse("D701ACBD-97D9-437B-A949-A4CF04A33521")).Result;
                if (story1 != null) { await storyRepository.Remove(story1); }

                var story2 = storyRepository.Get(Guid.Parse("4EADAFCD-7585-492C-A39D-878715441048")).Result;
                if (story2!= null) { await storyRepository.Remove(story2); }
            }
        }
    }
}
