using System;
using System.Collections.Generic;

namespace Stories.Domain.Model
{
    public class Timeline
    {
        public Timeline(Guid id, string timelineName)
        {
            if (Guid.Empty == id)
            {
                throw new ArgumentException("id is a required field.");
            }
            if (string.IsNullOrEmpty(timelineName))
            {
                throw new ArgumentException("timelineName is a required field.");
            }
        }
        public Guid PersonId { get; set; }
        public string TimelineName { get; set; }
        public IDictionary<Guid, Post> Posts { get; set; }
    }
}
