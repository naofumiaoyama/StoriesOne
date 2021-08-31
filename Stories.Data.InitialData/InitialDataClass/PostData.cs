using Stories.Data.Entities;
using Stories.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.InitialData
{
    public class PostData
    {
        public async Task MakeData()
        {

            using (var context = new DatabaseContext())
            {
                GenericRepository<Post>postRepository = new GenericRepository<Post>(context);
                Post post1 = new Post();
                post1.Id = Guid.Parse("231A90BC-72E8-4A01-8967-73EE78E0D497");
                post1.StoryId = Guid.Parse("D701ACBD-97D9-437B-A949-A4CF04A33521");
                post1.Title = "Hello";
                post1.PostDateTime = DateTime.Now;
                post1.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                post1.CreateDate = DateTime.Now;
                post1.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                post1.UpdateDate = DateTime.Now;
                await postRepository.Add(post1);

                Post post2 = new Post();
                post2.Id = Guid.Parse("BD640647-F214-4661-8DAD-A097D33B665C");
                post2.StoryId = Guid.Parse("4EADAFCD-7585-492C-A39D-878715441048");
                post2.Title = "Hello2";
                post2.PostDateTime = DateTime.Now;
                post2.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                post2.CreateDate = DateTime.Now;
                post2.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                post2.UpdateDate = DateTime.Now;
                await postRepository.Add(post2);
            }
        }

        public async Task DeleteData()
        {
            using (var context = new DatabaseContext())
            {
                GenericRepository<Post> postRepository = new GenericRepository<Post>(context);
                var post1 = postRepository.Get(Guid.Parse("231A90BC-72E8-4A01-8967-73EE78E0D497")).Result;
                if (post1 != null) { await postRepository.Remove(post1); }

                var post2 = postRepository.Get(Guid.Parse("BD640647-F214-4661-8DAD-A097D33B665C")).Result;
                if (post2 != null) { await postRepository.Remove(post1); }
            }
        }
    }
}
