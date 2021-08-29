using System;
namespace Stories.Domain.Model
{
    public class Chapter
    {
        public Chapter(Guid id, int number, string content )
        {
            if (Guid.Empty == id)
            {
                throw new ArgumentException("id is a required field.");
            }
            if (number < 1)
            {
                throw new ArgumentException("chapterNumber needs over 0");
            }
            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentException("content is a required field.");
            }
            this.Id = id;
            this.Number = number;
            this.Content = content;
        }
        public Guid Id { get; private set; }
        public int Number { get; private set; }
        public string Content { get; private set; }
    }
}
