using System;
using System.ComponentModel.DataAnnotations;


namespace Stories.Data.Entities
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }
        public Story Story { get; set; }
        public string Title { get; set; }
        public Photo Image { get; set; }
        public Comment Comment { get; set; }
        public Timeline Timeline { get; set; }
        public ReactionMark ReactionMarks { get; set; }
    }


}    

