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
                story.PersonId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                story.GenreId = Guid.Parse("A130CB16-4349-48DB-9E10-764974E4102D");
                story.Title = "Titanic";
                story.Summary = "Start by a young couple meeting, falling in love and having a hard time being together";
                story.Thoughts = "Thats good1";
                story.StoryType = StoryType.WellKnown;
                story.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                story.CreateDate = DateTime.Now;
                story.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                story.UpdateDate = DateTime.Now;
                await storyRepository.Add(story);

                Story story2 = new Story();
                story2.Id = Guid.Parse("4EADAFCD-7585-492C-A39D-878715441048");
                story2.PersonId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                story2.GenreId = Guid.Parse("01CE57F8-C669-43B9-A6E5-3B0E6558838C");
                story2.Title = "Lovebirds";
                story2.Summary = "The two people who believe that love knows no age";
                story2.Thoughts = "Thats good2";
                story2.StoryType = StoryType.Original;
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
