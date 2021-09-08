using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Domain.Model
{
    public class Picture
    {
        public Picture(Guid id, PictureOwnerType pictureOwnerType, string url)
        {
            if (Guid.Empty == id)
            {
                throw new ArgumentException("id is a required field.");
            }
            if (!PictureOwnerType.IsDefined(pictureOwnerType))
            {
                throw new ArgumentException("The pictureType has not been defined.");
            }
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("url is a required field.");
            }
            this.Id = id;
            this.PictureOwnerType = pictureOwnerType;
            this.Url = url;
        }
        public Guid Id { get; private set; }
        public PictureOwnerType PictureOwnerType { get; private set; }
        public string Url { get; private set; }
    }

    public enum PictureOwnerType
    {
        UserProfile = 1,
        Post = 2,
        Story = 3
    }
}
