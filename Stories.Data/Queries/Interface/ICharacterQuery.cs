﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stories.Domain.Model;

namespace Stories.Data.Queries.Interface
{
   public interface ICharacterQuery
    {
        Task<IDictionary<Guid, Character>> Get(Guid guid);
    }
}
