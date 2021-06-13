using System;
using System.Collections.Generic;

namespace Stories.Domain.Model
{
    public class Story
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public List<Body> Bodies { get; set; }
        public DateTime CreateDate { get; set;}
        public DateTime UpdateDate { get; set;}
    }
}
