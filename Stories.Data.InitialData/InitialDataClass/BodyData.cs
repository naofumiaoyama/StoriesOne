using Stories.Data.Entities;
using Stories.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.InitialData
{
    public class BodyData
    {
        public async Task MakeData()
        {
            using (var context = new DatabaseContext())
            {
                GenericRepository<BodyEntity> bodyRepository = new GenericRepository<BodyEntity>(context);
                BodyEntity body1 = new BodyEntity();
                body1.Id = Guid.Parse("EAF78FDA-A8A7-497B-98B8-B67F6E294D83");
                body1.StoryId = Guid.Parse("D701ACBD-97D9-437B-A949-A4CF04A33521");
                body1.ChapterNumber = 1;
                body1.BodyContent = "Love Story aaaaaaaaaaaaaaaaa";
                body1.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                body1.CreateDate = DateTime.Now;
                body1.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                body1.UpdateDate = DateTime.Now;
                await bodyRepository.Add(body1);

                BodyEntity body2 = new BodyEntity();
                body2.Id = Guid.Parse("6137AFDD-FDB8-408B-80FD-40882691FF1D");
                body2.StoryId = Guid.Parse("4EADAFCD-7585-492C-A39D-878715441048");
                body2.ChapterNumber = 1;
                body2.BodyContent = "Action Story main aaaaaaaaaaa";
                body2.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                body2.CreateDate = DateTime.Now;
                body2.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                body2.UpdateDate = DateTime.Now;
                await bodyRepository.Add(body2);

                BodyEntity body3 = new BodyEntity();
                body3.Id = Guid.Parse("0C1C9356-5D0E-461A-A9CC-CE0D4B99126E");
                body3.StoryId = Guid.Parse("4EADAFCD-7585-492C-A39D-878715441048");
                body3.ChapterNumber = 2;
                body3.BodyContent = "Action Story chapter2 aaaaaaaaaa";
                body3.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                body3.CreateDate = DateTime.Now;
                body3.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                body3.UpdateDate = DateTime.Now;
                await bodyRepository.Add(body3);
            }
        }
        public async Task DeleteData()
        {
            using (var context = new DatabaseContext())
            {
                GenericRepository<BodyEntity> bodyRepository = new GenericRepository<BodyEntity>(context);
                var body1 = bodyRepository.Get(Guid.Parse("EAF78FDA-A8A7-497B-98B8-B67F6E294D83")).Result;
                if (body1 != null) { await bodyRepository.Remove(body1); }

                var body2 = bodyRepository.Get(Guid.Parse("6137AFDD-FDB8-408B-80FD-40882691FF1D")).Result;
                if (body2 != null) { await bodyRepository.Remove(body2); }

                var body3 = bodyRepository.Get(Guid.Parse("0C1C9356-5D0E-461A-A9CC-CE0D4B99126E")).Result;
                if (body3 != null) { await bodyRepository.Remove(body3); }
            }
        }
    }
}
