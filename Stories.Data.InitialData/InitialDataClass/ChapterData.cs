using Stories.Data.Entities;
using Stories.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.InitialData
{
    public class ChapterData
    {
        public async Task MakeData()
        {
            using (var context = new DatabaseContext())
            {
                GenericRepository<Chapter> chapterRepository = new GenericRepository<Chapter>(context);
                Chapter chapter1 = new Chapter();
                chapter1.Id = Guid.Parse("EAF78FDA-A8A7-497B-98B8-B67F6E294D83");
                chapter1.StoryId = Guid.Parse("D701ACBD-97D9-437B-A949-A4CF04A33521");
                chapter1.Number = 1;
                chapter1.Content = "Love Story aaaaaaaaaaaaaaaaa";
                chapter1.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                chapter1.CreateDate = DateTime.Now;
                chapter1.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                chapter1.UpdateDate = DateTime.Now;
                await chapterRepository.Add(chapter1);

                Chapter chapter2 = new Chapter();
                chapter2.Id = Guid.Parse("6137AFDD-FDB8-408B-80FD-40882691FF1D");
                chapter2.StoryId = Guid.Parse("4EADAFCD-7585-492C-A39D-878715441048");
                chapter2.Number = 1;
                chapter2.Content = "Action Story main aaaaaaaaaaa";
                chapter2.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                chapter2.CreateDate = DateTime.Now;
                chapter2.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                chapter2.UpdateDate = DateTime.Now;
                await chapterRepository.Add(chapter2);

                Chapter chapter3 = new Chapter();
                chapter3.Id = Guid.Parse("0C1C9356-5D0E-461A-A9CC-CE0D4B99126E");
                chapter3.StoryId = Guid.Parse("4EADAFCD-7585-492C-A39D-878715441048");
                chapter3.Number = 2;
                chapter3.Content = "Action Story chapter2 aaaaaaaaaa";
                chapter3.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                chapter3.CreateDate = DateTime.Now;
                chapter3.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                chapter3.UpdateDate = DateTime.Now;
                await chapterRepository.Add(chapter3);
            }
        }
        public async Task DeleteData()
        {
            using (var context = new DatabaseContext())
            {
                GenericRepository<Chapter> chapterRepository = new GenericRepository<Chapter>(context);
                var body1 = chapterRepository.Get(Guid.Parse("EAF78FDA-A8A7-497B-98B8-B67F6E294D83")).Result;
                if (body1 != null) { await chapterRepository.Remove(body1); }

                var body2 = chapterRepository.Get(Guid.Parse("6137AFDD-FDB8-408B-80FD-40882691FF1D")).Result;
                if (body2 != null) { await chapterRepository.Remove(body2); }

                var body3 = chapterRepository.Get(Guid.Parse("0C1C9356-5D0E-461A-A9CC-CE0D4B99126E")).Result;
                if (body3 != null) { await chapterRepository.Remove(body3); }
            }
        }
    }
}
