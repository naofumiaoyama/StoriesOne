using Stories.Data.Entities;
using Stories.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.InitialData
{
    public class NotificationData
    {
        public async Task MakeData()
        {
            using (var context = new DatabaseContext())
            {
                GenericRepository<Notification> notificationRepository = new GenericRepository<Notification>(context);
                Notification notification = new Notification();
                Picture picture = new Picture();
                picture.Id = Guid.Parse("4532077D-3FCC-4B7B-9E9C-5EB05C4703F6");
                picture.Url = "Https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.forkknifeswoon.com%2Fwp-content%2Fuploads%2F2014%2F10%2Fsimple-homemade-chicken-ramen-fork-knife-swoon-01.jpg&imgrefurl=https%3A%2F%2Fwww.forkknifeswoon.com%2Fsimple-homemade-chicken-ramen%2F&tbnid=xvuanwzsBotXAM&vet=12ahUKEwi0q92A1t_yAhVK95QKHfbIAT4QMygBegUIARDfAQ..i&docid=Pt4KygPKLwIZ3M&w=690&h=862&itg=1&q=ramen%20pic&ved=2ahUKEwi0q92A1t_yAhVK95QKHfbIAT4QMygBegUIARDfAQ";
                picture.PictureOwnerType = PictureOwnerType.Person;
                notification.Id = Guid.Parse("9dc16535-6133-4487-a4ef-36eb8d9ce084");
                notification.DispImage = picture;
                notification.Contents = "Angelina Jolie reacted to your story";
                notification.UrlLink = "https://www.vanityfair.com/style/2020/11/angelina-jolie-brad-pitt-divorce-judge-not-removed";
                notification.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                notification.CreateDate = DateTime.Now;
                notification.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                notification.UpdateDate = DateTime.Now;
                await notificationRepository.Add(notification);

                Notification notification2 = new Notification();
                notification2.Id = Guid.Parse("5006E057-4682-4EA6-BA61-C1FF7A63492C");
                Picture picture2 = new Picture();
                picture2.Id = Guid.Parse("49EF9B2B-46C1-4532-93DD-7A425CE373AE");
                picture2.Url = "https://www.google.com/search?q=bella+poarch&sxsrf=AOaemvJZNQ8yH4gzPnt1QMGZJiWNUFue3g:1630809566816&source=lnms&tbm=isch&sa=X&ved=2ahUKEwjHhLSH5-byAhUtCqYKHVusCI4Q_AUoAXoECAEQAw&biw=1545&bih=801#imgrc=ae0PtsvQPhKSmM";
                picture2.PictureOwnerType = PictureOwnerType.Person;
                notification2.DispImage = picture;
                notification2.Contents = "Bella Poarch commented to your post";
                notification2.UrlLink = "https://www.scmp.com/magazines/style/celebrity/article/3092612/gong-yoo-41-coronavirus-aid-his-netflix-debut-4-things";
                notification.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                notification.CreateDate = DateTime.Now;
                notification.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                notification.UpdateDate = DateTime.Now;
                await notificationRepository.Add(notification2);
            }
        }

        public async Task DeleteData()
        {
            using (var context = new DatabaseContext())
            {
                GenericRepository<Notification> notificationRepository = new GenericRepository<Notification>(context);
                GenericRepository<Picture> pictureRepository = new GenericRepository<Picture>(context);

                var notification = notificationRepository.Get(Guid.Parse("9dc16535-6133-4487-a4ef-36eb8d9ce084")).Result;
                
                if(notification != null) { await notificationRepository.Remove(notification); }

                var notification2 = notificationRepository.Get(Guid.Parse("5006E057-4682-4EA6-BA61-C1FF7A63492C")).Result;
                if (notification2 != null) { await notificationRepository.Remove(notification2); }

                var picture = pictureRepository.Get(Guid.Parse("4532077D-3FCC-4B7B-9E9C-5EB05C4703F6")).Result;
                if (picture != null) { await pictureRepository.Remove(picture); }

                var picture2 = pictureRepository.Get(Guid.Parse("49EF9B2B-46C1-4532-93DD-7A425CE373AE")).Result;
                if (picture2 != null) { await pictureRepository.Remove(picture2); }
            }
        }
    }
}
