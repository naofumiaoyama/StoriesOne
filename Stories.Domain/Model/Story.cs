using System;
namespace Stories.Domain.Model
{
    public class Story
    {
            public string Title { get; set; }
            public Person Authur { get; set; }
            public string Summary { get; set; }
            public string Body { get; set; }
            public DateTime CreateDate { get; set;}
            public DateTime UpdateDate { get; set;}
    }
}
