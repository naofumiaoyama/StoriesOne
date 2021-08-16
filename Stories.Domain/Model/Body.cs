using System;
namespace Stories.Domain.Model
{
    public class Body
    {
        public Body(Guid id, int chapterNumber, string bodyContent )
        {
            if (Guid.Empty == id)
            {
                throw new ArgumentException("id is a required field.");
            }
            if (chapterNumber < 1)
            {
                throw new ArgumentException("chapterNumber needs over 0");
            }
            if (string.IsNullOrEmpty(bodyContent))
            {
                throw new ArgumentException("bodyContent is a required field.");
            }
            this.Id = id;
            this.ChapterNumber = chapterNumber;
            this.BodyContent = bodyContent;
        }
        public Guid Id { get; set; }
        public int ChapterNumber { get; set; }
        public string BodyContent { get; set; }
    }
}
