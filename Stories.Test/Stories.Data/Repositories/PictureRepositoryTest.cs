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
  public  class PictureRepositoryTest
    {
        [TestMethod]
        public async Task CRUDTest()
        {
            using (var context = new DatabaseContext())
            {
                //adding
                GenericRepository<PictureEntity>pictureRespository = new GenericRepository<PictureEntity>(context);
                PictureEntity pictureEntity = new PictureEntity();
                pictureEntity.Id = Guid.NewGuid();
                pictureEntity.Url = "http://www.photo.com";
                pictureEntity.PictureType = PictureType.UserProfile;
                await pictureRespository.Add(pictureEntity);

                //Getting
                var getPhoto = await pictureRespository.Get(pictureEntity.Id);

                Assert.AreEqual(getPhoto.Url, pictureEntity.Url);
                Assert.AreEqual(getPhoto.PictureType, pictureEntity.PictureType);

                //Updating
                pictureEntity.Url = "http://www.stories.com";
                await pictureRespository.Update(pictureEntity);
                var updatePicture = await pictureRespository.Get(pictureEntity.Id);
                Assert.AreEqual(updatePicture.Url, pictureEntity.Url);
                Assert.AreEqual(updatePicture.PictureType, pictureEntity.PictureType);

                ////Removing
                await pictureRespository.Remove(pictureEntity);
                var resultPhoto = pictureRespository.Get(pictureEntity.Id).Result;
                Assert.AreEqual(resultPhoto, null);
            }
        }
    }
}
