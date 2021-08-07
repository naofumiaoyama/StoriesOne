using System;
namespace Stories.Domain.Model
{
    public class MessageModel
    {
        public string Title { get; set; }
        public UserModel User { get; set; }
        public string Content { get; set; }
        
    }
}
