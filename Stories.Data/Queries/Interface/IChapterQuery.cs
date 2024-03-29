﻿using Stories.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Queries.Interface
{
   public interface IChapterQuery
    {
        Task<IDictionary<Guid, Chapter>> Get(Guid guid);
    }
}
