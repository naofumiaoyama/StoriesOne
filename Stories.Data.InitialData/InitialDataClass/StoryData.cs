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
                story2.GenreId = Guid.Parse("7222231D-7EF9-490B-9548-6D6C161F2329");
                story2.Title = "Lovebirds";
                story2.Summary = "The two people who believe that love knows no age";
                story2.Thoughts = "Thats good2";
                story2.StoryType = StoryType.Original;
                story2.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                story2.CreateDate = DateTime.Now;
                story2.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                story2.UpdateDate = DateTime.Now;
                await storyRepository.Add(story2);

                Story story3 = new Story();
                story3.Id = Guid.Parse("FC8849B3-AB67-4D05-8FFA-C2ED67CAC709");
                story3.PersonId = Guid.Parse("F7A70CB7-F46D-4A94-88CD-6B0284CBE96F");
                story3.GenreId = Guid.Parse("64a25e25-2d0b-46e6-8488-dc089bb9a92e");
                story3.Title = "Lovebirds2";
                story3.Summary = "The two people who believe that love knows no age";
                story3.Thoughts = "Thats good3";
                story3.StoryType = StoryType.Original;
                story3.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                story3.CreateDate = DateTime.Now;
                story3.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                story3.UpdateDate = DateTime.Now;
                await storyRepository.Add(story3);

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

                var story3 = storyRepository.Get(Guid.Parse("FC8849B3-AB67-4D05-8FFA-C2ED67CAC709")).Result;
                if (story3 != null) { await storyRepository.Remove(story3); }
            }
        }
    }
}
