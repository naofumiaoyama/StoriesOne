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
                comment.CommentPersonId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                comment.PostTime = DateTime.Now;
                await commentRepository.Add(comment);

                //Getting
                var getcomment = await commentRepository.Get(comment.Id);
                Assert.AreEqual(getcomment.Id, comment.Id);
                Assert.AreEqual(getcomment.CommentText, comment.CommentText);
                Assert.AreEqual(getcomment.CommentPersonId,comment.CommentPersonId);
                Assert.AreEqual(getcomment.PostTime, comment.PostTime);

                //Updating
                comment.CommentText = "CDE";
                comment.CommentPersonId = Guid.Parse("54AE5D62-D355-46D3-81C7-A35806A4E9BB");
                var updateComment = await commentRepository.Get(comment.Id);
                Assert.AreEqual(updateComment.CommentText, comment.CommentText);       
                Assert.AreEqual(updateComment.CommentPersonId, comment.CommentPersonId);

                //Removing
                await commentRepository.Delete(comment);
                var resultComment = commentRepository.Get(comment.Id).Result;
                Assert.AreEqual(resultComment, null);

            }
        }
    }
}