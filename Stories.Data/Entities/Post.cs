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
        public DateTime PostDate { get; set; }
        public Guid CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
    }


}    

