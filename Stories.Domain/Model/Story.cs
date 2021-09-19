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
        public Guid Id { get; private set; }
        public StoryType StoryType { get; private  set; }
        public string Title { get; private set; }
        public string Summary { get; private set; }
        public string Thoughts { get; private set; }
        public Genre Genre { get; private set; }
        public IDictionary<Guid, Chapter> Chapters { get; private set; }
        public IDictionary<Guid, Character> Characters { get; private set; }
        public DateTime CreateDate { get; private set;}
        public DateTime UpdateDate { get; private set;}
    }

    public enum StoryType
    {
        WellKnown = 1,
        Original = 2
    }

}
