﻿using Stories.Data.Entities;
using Stories.Data.Repositories;
using Stories.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.InitialData
{
    public class ReactionMarkData
    {
        public async Task MakeData()
        {
            using (var context = new DatabaseContext())
            {
                GenericRepository<Entities.ReactionMark> reactionMarkRepository = new GenericRepository<Entities.ReactionMark>(context);
                Entities.ReactionMark reactionMark = new Entities.ReactionMark();
                reactionMark.Id = Guid.Parse("42697A78-A3B6-4C49-AA5A-9A0F7F9B6405");
                reactionMark.PostId = Guid.Parse("231A90BC-72E8-4A01-8967-73EE78E0D497");
                reactionMark.Url = "http://www.shortstories.com";
                reactionMark.Name = "helloworld";
                reactionMark.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                reactionMark.CreateDate = DateTime.Now;
                reactionMark.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                reactionMark.UpdateDate = DateTime.Now;
                await reactionMarkRepository.Add(reactionMark);


                Entities.ReactionMark reactionMark2 = new Entities.ReactionMark();
                reactionMark2.Id = Guid.Parse("529099F0-B652-4CBF-AE9B-27E842B37B0D");
                reactionMark2.PostId = Guid.Parse("BD640647-F214-4661-8DAD-A097D33B665C");
                reactionMark2.Url = "http://www.short.net";
                reactionMark2.Name = "Hello";
                reactionMark2.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                reactionMark2.CreateDate = DateTime.Now;
                reactionMark2.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                reactionMark2.UpdateDate = DateTime.Now;
                await reactionMarkRepository.Add(reactionMark2);
            }
        }

        public async Task DeleteData()
        {
            using (var context = new DatabaseContext())
            {
                GenericRepository<Entities.ReactionMark> reactionMarkRepository = new GenericRepository<Entities.ReactionMark>(context);
                var reactionMark1 = reactionMarkRepository.Get(Guid.Parse("42697A78-A3B6-4C49-AA5A-9A0F7F9B6405")).Result;
                if (reactionMark1 != null) { await reactionMarkRepository.Remove(reactionMark1); }

                var story2 = reactionMarkRepository.Get(Guid.Parse("529099F0-B652-4CBF-AE9B-27E842B37B0D")).Result;
                if (story2 != null) { await reactionMarkRepository.Remove(story2); }
            }
        }

    }
}
