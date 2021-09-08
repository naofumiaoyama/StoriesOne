using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stories.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Test.Stories.Data.Queries
{
    [TestClass]
    public class NotificationQueryTest
    {
        [TestMethod]
        public async Task GetTest()
        {
            var query = new NotificationQuery();
            // var queryPic = new PictureQuery();
            var notificationId = Guid.Parse("5006E057-4682-4EA6-BA61-C1FF7A63492C");
            var notification = await query.Get(notificationId);
            //var picture = await queryPic.Get(notification.PictureId);
            //notification.DispImage = picture;
            Assert.AreEqual(notificationId, Guid.Parse("5006E057-4682-4EA6-BA61-C1FF7A63492C"));
            //Assert.AreEqual(notification.DispImage.Id, notification.PictureId);
            Assert.AreEqual(notification.Contents, "Bella Poarch commented to your post");
        }
    }
}
