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
    public class CommentRepositoryTest
    {
        [TestMethod]
        public async Task CrudTest()
        {
            using (var context = new DatabaseContext())
            {
                //adding
                GenericRepository<Comment>commentRepository = new GenericRepository<Comment>(context);
                Comment comment= new Comment();
                comment.Id = Guid.NewGuid();
                comment.PostId = Guid.Parse("231A90BC-72E8-4A01-8967-73EE78E0D497");
                comment.CommentText = "Abc";
                comment.PostTime = DateTime.Now;
                await commentRepository.Add(comment);

                //Getting
                var getcomment = await commentRepository.Get(comment.Id);
                Assert.AreEqual(getcomment.Id, comment.Id);
                Assert.AreEqual(getcomment.CommentText, comment.CommentText);
                Assert.AreEqual(getcomment.PostTime, comment.PostTime);

                //Updating
                comment.CommentText = "CDE";
                var updateComment = await commentRepository.Get(comment.Id);
                Assert.AreEqual(updateComment.CommentText, comment.CommentText);       

                //Removing
                await commentRepository.Remove(comment);
                var resultComment = commentRepository.Get(comment.Id).Result;
                Assert.AreEqual(resultComment, null);

            }
        }
    }
}