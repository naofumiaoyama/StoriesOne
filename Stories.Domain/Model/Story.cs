using System;
using System.Collections.Generic;

namespace Stories.Domain.Model
{
    public class Story
    {
        public Story(Guid id, string title, string summary)
        {
            if (Guid.Empty == id)
            {
                throw new ArgumentException("id is a required field.");
            }
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("title is a required field.");
            }
            if (string.IsNullOrEmpty(summary))
            {
                throw new ArgumentException("summary is a required field.");
            }
            this.Id = id;
            this.Title = title;
            this.Summary = summary;
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public IDictionary<Guid, Body> Bodies { get; set; }
        public IDictionary<Guid, Character> Characters { get; set; }
        public DateTime CreateDate { get; set;}
        public DateTime UpdateDate { get; set;}
    }
}
