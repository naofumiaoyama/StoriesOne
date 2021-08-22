using System;
namespace Stories.Domain.Model
{
    public class Chapter
    {
        public Chapter(Guid id, int number, string bodyContent )
        {
            if (Guid.Empty == id)
            {
                throw new ArgumentException("id is a required field.");
            }
            if (number < 1)
            {
                throw new ArgumentException("chapterNumber needs over 0");
            }
            if (string.IsNullOrEmpty(bodyContent))
            {
                throw new ArgumentException("bodyContent is a required field.");
            }
            this.Id = id;
            this.Number = number;
            this.BodyContent = bodyContent;
        }
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string BodyContent { get; set; }
    }
}
