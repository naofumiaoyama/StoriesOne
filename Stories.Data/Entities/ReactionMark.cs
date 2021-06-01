using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Stories.Data.Entities
{
    public class ReactionMark
    {
        [Key]
        public Guid Id { get; set; }
        public Post Post { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }

    }
}
