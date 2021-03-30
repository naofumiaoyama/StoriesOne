using System;
namespace Stories.Api.Model
{
    public class Story
    {
            public string Title { get; set; }
            //Author { }
            public string Summary { get; set; }
            public string Body { get; set; }
            public DateTime CreateDate { get; set;}
            public DateTime UpdateDate { get; set;}
    }
}
