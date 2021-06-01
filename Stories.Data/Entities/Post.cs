using System;
using System.ComponentModel.DataAnnotations;


namespace Stories.Data.Entities
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }
        public Timeline Timeline { get; set; }
        public string Title { get; set; }       
    }


}    

