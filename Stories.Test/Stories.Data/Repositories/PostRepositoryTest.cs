using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stories.Data;
using Stories.Data.Entities;
using Stories.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Test.Stories.Data.Repositories
{
    [TestClass]
   public class PostRepositoryTest
    {
        [TestMethod]
        public async Task CRUDTest()
        {
            using(var context = new DatabaseContext())
            {
                //adding
                GenericRepository<Post>postRepository = new GenericRepository<Post>(context);
                Post post = new Post();
                post.Id = Guid.Parse("908FD83F-93C8-41BD-B3CA-438D06996F85");
                post.TimelineId = Guid.Parse("09604DDD-D01A-4307-BD5D-908594216904");
                post.Title = "Hello";
                
                await postRepository.Add(post);

                //Getting
                var getPost = await postRepository.Get(post.Id);

                Assert.AreEqual(getPost.Id, post.Id);
                Assert.AreEqual(getPost.Title, post.Title);

                //Updating
                post.Title = "Stories";
                await postRepository.Update(post);
                var updatePost = await postRepository.Get(post.Id);
                Assert.AreEqual(updatePost.Title, "Stories");

                //Removing
               await postRepository.Remove(post);
               var resultPost = postRepository.Get(post.Id).Result;
               Assert.AreEqual(resultPost, null);
            }
        }
    }
}
