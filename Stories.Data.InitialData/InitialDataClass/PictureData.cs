﻿using Stories.Data.Entities;
using Stories.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.InitialData
{
  public  class PictureData
    {
        public async Task MakeData()
        {
            using (var context = new DatabaseContext())
            {
                GenericRepository<Picture>pictureRepository = new GenericRepository<Picture>(context);
                Picture picture1 = new Picture();
                picture1.Id = Guid.Parse("66D994A3-C6B3-49A0-B775-915346FD890C");
                picture1.PictureOwnerType = PictureOwnerType.Person;
                picture1.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                picture1.CreateDate = DateTime.Now;
                picture1.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                picture1.UpdateDate = DateTime.Now;
                picture1.Url = "https://scontent-nrt1-1.xx.fbcdn.net/v/t1.6435-9/56391650_10218606827978007_2759002573368197120_n.jpg?_nc_cat=109&ccb=1-3&_nc_sid=09cbfe&_nc_ohc=j8b3XwPviYEAX8F_JD5&_nc_ht=scontent-nrt1-1.xx&oh=7ed7218190af8db52997a55df3d8ec57&oe=60DBCDB2";
                
                await pictureRepository.Add(picture1);

                Picture picture2 = new Picture();
                picture2.Id = Guid.Parse("5006e057-4682-4ea6-ba61-c1ff7a63492c");
                picture2.PictureOwnerType = PictureOwnerType.Person;
                picture2.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                picture2.CreateDate = DateTime.Now;
                picture2.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                picture2.UpdateDate = DateTime.Now;
                picture2.Url = "https://scontent-nrt1-1.xx.fbcdn.net/v/t1.6435-9/197204748_101752262154035_1080203619806412059_n.jpg?_nc_cat=101&ccb=1-3&_nc_sid=8bfeb9&_nc_ohc=WW_QOkcT8R4AX8Cqqpn&_nc_ht=scontent-nrt1-1.xx&oh=c0a48e1a5efcef78cf7324428711d047&oe=60DBD398";

                await pictureRepository.Add(picture2);      
            }
        }
        public async Task DeleteData()
        {

            using (var context = new DatabaseContext())
            {
                GenericRepository<Picture> pictureRepository = new GenericRepository<Picture>(context);
                var picture1 = pictureRepository.Get(Guid.Parse("66D994A3-C6B3-49A0-B775-915346FD890C")).Result;
                if (picture1 != null) { await pictureRepository.Remove(picture1); }

                var picture2 = pictureRepository.Get(Guid.Parse("5006e057-4682-4ea6-ba61-c1ff7a63492c")).Result;
                if (picture2 != null) { await pictureRepository.Remove(picture2); }
            }
        }
    }
}
