using Stories.Data.Entities;
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
                PictureRepository pictureRepository = new PictureRepository(context);
                Picture picture1 = new Picture();
                picture1.Id = Guid.Parse("CF2FD49A-A7CB-4523-8BED-C09B896026EF");
                picture1.PictureType = PictureType.UserProfile;
                picture1.Url = "https://scontent-nrt1-1.xx.fbcdn.net/v/t1.6435-9/56391650_10218606827978007_2759002573368197120_n.jpg?_nc_cat=109&ccb=1-3&_nc_sid=09cbfe&_nc_ohc=j8b3XwPviYEAX8F_JD5&_nc_ht=scontent-nrt1-1.xx&oh=7ed7218190af8db52997a55df3d8ec57&oe=60DBCDB2";

                await pictureRepository.Add(picture1);

                Picture picture2 = new Picture();
                picture2.Id = Guid.Parse("5006E057-4682-4EA6-BA61-C1FF7A63492C");
                picture2.PictureType = PictureType.UserProfile;
                picture2.Url = "https://scontent-nrt1-1.xx.fbcdn.net/v/t1.6435-9/197204748_101752262154035_1080203619806412059_n.jpg?_nc_cat=101&ccb=1-3&_nc_sid=8bfeb9&_nc_ohc=WW_QOkcT8R4AX8Cqqpn&_nc_ht=scontent-nrt1-1.xx&oh=c0a48e1a5efcef78cf7324428711d047&oe=60DBD398";

                await pictureRepository.Add(picture2);      
            }
        }
        public async Task DeleteData()
        {

            using (var context = new DatabaseContext())
            {
                PictureRepository pictureRepository = new PictureRepository(context);
                var picture1 = pictureRepository.Get(Guid.Parse("CF2FD49A-A7CB-4523-8BED-C09B896026EF")).Result;
                if (picture1 != null) { await pictureRepository.Delete(picture1); }

                var picture2 = pictureRepository.Get(Guid.Parse("5006E057-4682-4EA6-BA61-C1FF7A63492C")).Result;
                if (picture2 != null) { await pictureRepository.Delete(picture2); }
            }
        }
    }
}
