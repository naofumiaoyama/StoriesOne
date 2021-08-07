using System;
using System.Collections.Generic;

namespace Stories.Domain.Model
{
    public class TimelineModel
    {
        public Guid PersonId { get; set; }
        public string TimelineName { get; set; }
        public IDictionary<Guid, PostModel> Posts { get; set; }
    }
}
