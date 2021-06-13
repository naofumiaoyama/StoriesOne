using System;
namespace Stories.Domain.Model
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Story Story{ get; set;}
        public string User { get; set;}
    }
}
