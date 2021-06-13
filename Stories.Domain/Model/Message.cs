using System;
namespace Stories.Domain.Model
{
    public class Message
    {
        public string Title { get; set; }
        public User User { get; set; }
        public string Content { get; set; }
        
    }
}
