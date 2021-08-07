using System;
using System.Collections.Generic;

namespace Stories.Domain.Model
{
    public class StoryModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public IDictionary<Guid, BodyModel> Bodies { get; set; }
        public DateTime CreateDate { get; set;}
        public DateTime UpdateDate { get; set;}
    }
}
