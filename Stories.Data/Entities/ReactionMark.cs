using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Stories.Data.Entities
{
    public class ReactionMark
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }

    }
}
