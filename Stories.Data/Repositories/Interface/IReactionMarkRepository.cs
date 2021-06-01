using Stories.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Repositories
{
    public interface IReactionMarkRepository
    {
        Task<ReactionMark> Get(Guid id);
        Task Add(ReactionMark reactionMark);
        Task Update(ReactionMark reactionMark);
        Task Delete(ReactionMark reactionMark);
    }
}
