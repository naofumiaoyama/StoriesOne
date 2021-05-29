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
                CommentRepository commentRepository = new CommentRepository(context);
                Comment comment = new Comment();
                comment.Id = Guid.NewGuid();
                comment.CommentText = "Abc";
                comment.CommentUser = await new PersonRepository(context).Get(Guid.Parse("0E407699-EDE4-4C2B-8699-2DA8F2BD75E2"));
                comment.PostTime = DateTime.Now;
                await commentRepository.Add(comment);

                //Getting
                var getcomment = await commentRepository.Get(comment.Id);

                Assert.AreEqual(getcomment.Id, comment.Id);
                Assert.AreEqual(getcomment.CommentText, comment.CommentText);
                Assert.AreEqual(getcomment.CommentUser, comment.CommentUser);
                Assert.AreEqual(getcomment.PostTime, comment.PostTime);

                //Updating
                comment.CommentText = "CDE";
                // comment.CommentUser = await new PersonRepository(context).Get(Guid.Parse("0E407699-EDE4-4C2B-8699-2DA8F2BD75E2"));
                await commentRepository.Update(comment);
                var updateComment = await commentRepository.Get(comment.Id);
                Assert.AreEqual(updateComment.CommentText, comment.CommentText);
                Assert.AreEqual(updateComment.CommentUser, comment.CommentUser);

                //Removing
                await commentRepository.Delete(comment);
                var resultComment = commentRepository.Get(comment.Id).Result;
                Assert.AreEqual(resultComment, null);





            }
        }
    }
}