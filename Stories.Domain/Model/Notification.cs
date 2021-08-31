using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Domain.Model
{
   public class Notification
   {
     public Notification(Guid id, Picture dispImage, string contents, string urlLink)
     {
            if (Guid.Empty == id)
            {
                throw new ArgumentException("id is a required field.");
            }
            if (dispImage == null)
            {
                throw new ArgumentException("dispImage cannot be null");
            }
            if (string.IsNullOrEmpty(contents))
            {
                throw new ArgumentException("contents is is required field");
            }  
            if (string.IsNullOrEmpty(urlLink))
            {
                throw new ArgumentException("urlLink is a required field");
            }
            Id = id;
            DispImage = dispImage;
            Contents = contents;
            UrlLink = urlLink;
     }

        public Guid Id { get; private set; }
        public Picture DispImage { get; private set; }
        public string Contents { get; private set; }
        public string UrlLink { get; private set; }
   }
}
