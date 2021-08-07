using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Stories.Data.Entities
{
    public class ReactionMark : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public bool Clicked { get; set; }
    }
}
