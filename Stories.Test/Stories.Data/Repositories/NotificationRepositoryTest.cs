using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stories.Data;
using Stories.Data.Entities;
using Stories.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Test.Stories.Data.Repositories
{
    [TestClass]
   public class NotificationRepositoryTest
    {

        [TestMethod]
        public async Task CRUDTest()
        {
            using (var context = new DatabaseContext())
            {
                GenericRepository<Notification> notificationRepository = new GenericRepository<Notification>(context);
               
                //adding
                Notification notification = new Notification();
                Picture picture = new Picture();
                picture.Id = Guid.NewGuid();
                picture.PictureOwnerType = PictureOwnerType.Person;
                picture.Url = "Https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.forkknifeswoon.com%2Fwp-content%2Fuploads%2F2014%2F10%2Fsimple-homemade-chicken-ramen-fork-knife-swoon-01.jpg&imgrefurl=https%3A%2F%2Fwww.forkknifeswoon.com%2Fsimple-homemade-chicken-ramen%2F&tbnid=xvuanwzsBotXAM&vet=12ahUKEwi0q92A1t_yAhVK95QKHfbIAT4QMygBegUIARDfAQ..i&docid=Pt4KygPKLwIZ3M&w=690&h=862&itg=1&q=ramen%20pic&ved=2ahUKEwi0q92A1t_yAhVK95QKHfbIAT4QMygBegUIARDfAQ";
                notification.Id = Guid.Parse("2CBE22F9-99F0-42AD-9779-255B8F781FE4");
                notification.DispImage = picture;
                notification.UrlLink = "https://www.vanityfair.com/style/2020/11/angelina-jolie-brad-pitt-divorce-judge-not-removed";
                notification.Contents = "Angelina Jolie reacted to your story";
                notification.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                notification.CreateDate = DateTime.Now;
                notification.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                notification.UpdateDate = DateTime.Now;
                await notificationRepository.Add(notification);


                //getting
                var getNotification = notificationRepository.Get(notification.Id).Result;
                Assert.AreEqual(getNotification.Id, notification.Id);
                Assert.AreEqual(getNotification.DispImage, notification.DispImage);
                Assert.AreEqual(getNotification.UrlLink, notification.UrlLink);
                Assert.AreEqual(getNotification.Contents, notification.Contents);

                //updating
                picture.PictureOwnerType = PictureOwnerType.Person;
                picture.Url = "https://www.google.com/search?q=bella+poarch&sxsrf=AOaemvJZNQ8yH4gzPnt1QMGZJiWNUFue3g:1630809566816&source=lnms&tbm=isch&sa=X&ved=2ahUKEwjHhLSH5-byAhUtCqYKHVusCI4Q_AUoAXoECAEQAw&biw=1545&bih=801#imgrc=ae0PtsvQPhKSmM";
                notification.DispImage = picture;
                notification.UrlLink = "https://www.scmp.com/magazines/style/celebrity/article/3092612/gong-yoo-41-coronavirus-aid-his-netflix-debut-4-things";
                notification.Contents = "Bella Poarch commented to your post";

                //Removing
                await notificationRepository.Remove(notification);
                var resultnotification = notificationRepository.Get(notification.Id).Result;
                Assert.AreEqual(resultnotification, null);
            }
        }
    }
}
