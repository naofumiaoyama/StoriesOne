using System;
namespace Stories.Domain.Model
{
    public class Body
    {
        public Guid Id { get; set; }
        public Guid StoryId { get; set; }
        public int ChapterNumber { get; set; }
        public string BodyContent { get; set; }
    }
}
