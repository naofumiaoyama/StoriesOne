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
                StoryRepository storyRepository = new StoryRepository(context);
                Story story = new Story();
                story.Id = Guid.NewGuid();
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
                story2.Id = Guid.NewGuid();
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

                StoryRepository storyRepository = new StoryRepository(context);
                var story1 = storyRepository.Get(Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F")).Result;
                if (story1 != null) { await storyRepository.Delete(story1); }

                var story2 = storyRepository.Get(Guid.Parse("EEFB1E9D-4E17-43A3-A690-F374D27D36DE")).Result;
                if (story2!= null) { await storyRepository.Delete(story2); }
            }
        }
    }
}
