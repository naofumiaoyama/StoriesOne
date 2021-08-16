using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Domain.Model
{
    public class Picture
    {
        public Picture(Guid id, PictureType pictureType, string url)
        {
            if (Guid.Empty == id)
            {
                throw new ArgumentException("id is a required field.");
            }
            if (!PictureType.IsDefined(pictureType))
            {
                throw new ArgumentException("The pictureType has not been defined.");
            }
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("url is a required field.");
            }
            this.Id = id;
            this.PictureType = pictureType;
            this.Url = url;
        }
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
