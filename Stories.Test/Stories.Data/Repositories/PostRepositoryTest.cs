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
                PostRepository postRepository = new PostRepository(context);
                Post post = new Post();
                post.Id = Guid.NewGuid(); 
                post.Timeline = new Timeline();
                await postRepository.Add(post);

                //Getting
                var getPost = await postRepository.Get(post.Id);

                Assert.AreEqual(getPost.Id, post.Id);
                Assert.AreEqual(getPost.Title, post.Title);
                Assert.AreEqual(getPost.Timeline, post.Timeline);

                //Updating
                post.Title = "Stories";
                await postRepository.Update(post);
                var updatePost = await postRepository.Get(post.Id);
                Assert.AreEqual(updatePost.Title, post.Title);

                ////Removing
               await postRepository.Delete(post);
               var resultPost = postRepository.Get(post.Id).Result;
               Assert.AreEqual(resultPost, null);
            }
        }
    }
}
