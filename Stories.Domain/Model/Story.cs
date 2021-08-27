using System;
using System.Collections.Generic;

namespace Stories.Domain.Model
{
    public class Story
    {
        public Story(Guid id, string title, string summary, StoryType storyType)
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
            if (!StoryType.IsDefined(storyType))
            {
                throw new ArgumentException("The storyType has not been defined.");
            }
            
            this.Id = id;
            this.Title = title;
            this.Summary = summary;
            this.StoryType = storyType;
        }
        public Guid Id { get; set; }
        public StoryType StoryType { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Thoughts { get; set; }
        public Genre Genre { get; set; }
        public IDictionary<Guid, Chapter> Chapters { get; set; }
        public IDictionary<Guid, Character> Characters { get; set; }
        public DateTime CreateDate { get; set;}
        public DateTime UpdateDate { get; set;}
    }

    public enum StoryType
    {
        WellKnown = 1,
        Original = 2
    }

}
