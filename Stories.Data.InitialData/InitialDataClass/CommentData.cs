using Stories.Data.Entities;
using Stories.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.InitialData
{
  public  class CommentData
    {
        public async Task MakeData()
        {
            using (var context = new DatabaseContext())
            {
                GenericRepository<CommentEntity>commentRepository = new GenericRepository<CommentEntity>(context);
                CommentEntity comment1 = new CommentEntity();
                comment1.Id = Guid.Parse("68AFFD37-1590-4EC9-9596-76A99F3AD892");
                comment1.CommentText = "Abc";
                comment1.CommentPersonId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                comment1.PostTime = DateTime.Now;
                comment1.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                comment1.CreateDate = DateTime.Now;
                comment1.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                comment1.UpdateDate = DateTime.Now;
                await commentRepository.Add(comment1);

                CommentEntity comment2 = new CommentEntity();
                comment2.Id = Guid.Parse("9C886F4A-5BCE-4FEF-82AB-BF3BB922FACD");
                comment2.CommentText = "Abc";
                comment2.CommentPersonId = Guid.Parse("F7A70CB7-F46D-4A94-88CD-6B0284CBE96F");
                comment2.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                comment2.CreateDate = DateTime.Now;
                comment2.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                comment2.UpdateDate = DateTime.Now;
                comment2.PostTime = DateTime.Now;

                await commentRepository.Add(comment2);

                CommentEntity comment3 = new CommentEntity();
                comment3.Id = Guid.Parse("a108c926-e915-45d3-8daa-63fca0ddf142");
                comment3.CommentText = "Abc";
                comment3.CommentPersonId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                comment3.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                comment3.CreateDate = DateTime.Now;
                comment3.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                comment3.UpdateDate = DateTime.Now;
                comment3.PostTime = DateTime.Now;

                await commentRepository.Add(comment3);
            }
        }
        public async Task DeleteData()
        {

            using (var context = new DatabaseContext())
            {
                GenericRepository<CommentEntity> commentRepository = new GenericRepository<CommentEntity>(context);
                var comment1 = commentRepository.Get(Guid.Parse("68AFFD37-1590-4EC9-9596-76A99F3AD892")).Result;
                if (comment1 != null) { await commentRepository.Remove(comment1); }

                var comment2 = commentRepository.Get(Guid.Parse("9C886F4A-5BCE-4FEF-82AB-BF3BB922FACD")).Result;
                if (comment2 != null) { await commentRepository.Remove(comment2); }

                var comment3 = commentRepository.Get(Guid.Parse("a108c926-e915-45d3-8daa-63fca0ddf142")).Result;
                if (comment3 != null) { await commentRepository.Remove(comment3); }


            }
        }
    }
}
