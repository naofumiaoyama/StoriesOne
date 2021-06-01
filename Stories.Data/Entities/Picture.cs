using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stories.Data.Entities
{
    public class Picture
    {
        public Guid Id { get; set; }
        public PictureType PictureType { get; set; }
        public string Url { get; set; }
    }

    public enum PictureType
    {
        UserProfile = 1,
        Post = 2,
        Story = 3
    }
}
