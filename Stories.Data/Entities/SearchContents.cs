using System;
using System.ComponentModel.DataAnnotations;

namespace Stories.Data.Entities
{
    public class SearchContents
    { 
        [Key]
        public string SearchWord { get; set; }

    }
}
