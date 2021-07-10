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
                GenericRepository<CommentEntity>commentRepository = new GenericRepository<CommentEntity>(context);
                CommentEntity commentEntity = new CommentEntity();
                commentEntity.Id = Guid.NewGuid();
                commentEntity.CommentText = "Abc";
                commentEntity.CommentPersonId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                commentEntity.PostTime = DateTime.Now;
                await commentRepository.Add(commentEntity);

                //Getting
                var getcomment = await commentRepository.Get(commentEntity.Id);
                Assert.AreEqual(getcomment.Id, commentEntity.Id);
                Assert.AreEqual(getcomment.CommentText, commentEntity.CommentText);
                Assert.AreEqual(getcomment.CommentPersonId,commentEntity.CommentPersonId);
                Assert.AreEqual(getcomment.PostTime, commentEntity.PostTime);

                //Updating
                commentEntity.CommentText = "CDE";
                commentEntity.CommentPersonId = Guid.Parse("54AE5D62-D355-46D3-81C7-A35806A4E9BB");
                var updateComment = await commentRepository.Get(commentEntity.Id);
                Assert.AreEqual(updateComment.CommentText, commentEntity.CommentText);       
                Assert.AreEqual(updateComment.CommentPersonId, commentEntity.CommentPersonId);

                //Removing
                await commentRepository.Remove(commentEntity);
                var resultComment = commentRepository.Get(commentEntity.Id).Result;
                Assert.AreEqual(resultComment, null);

            }
        }
    }
}