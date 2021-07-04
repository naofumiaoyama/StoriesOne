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
                PostRepository postRepository = new PostRepository(context);
                Post post1 = new Post();
                post1.Id = Guid.Parse("231A90BC-72E8-4A01-8967-73EE78E0D497");
                post1.TimelineId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                post1.Title = "Hello";
                post1.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                post1.CreateDate = DateTime.Now;
                post1.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                post1.UpdateDate = DateTime.Now;
                await postRepository.Add(post1);
            }
        }

        public async Task DeleteData()
        {
            using (var context = new DatabaseContext())
            {
                PostRepository postRepository = new PostRepository(context);
                var post1 = postRepository.Get(Guid.Parse("231A90BC-72E8-4A01-8967-73EE78E0D497")).Result;
                if (post1 != null) { await postRepository.Delete(post1); }
            }
        }
    }
}
