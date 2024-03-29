﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
                GenericRepository<Picture>pictureRespository = new GenericRepository<Picture>(context);
                Picture picture = new Picture();
                picture.Id = Guid.NewGuid();
                picture.Url = "http://www.photo.com";
                picture.PictureOwnerType = PictureOwnerType.Person;
                await pictureRespository.Add(picture);

                //Getting
                var getPhoto = await pictureRespository.Get(picture.Id);

                Assert.AreEqual(getPhoto.Url, picture.Url);
                Assert.AreEqual(getPhoto.PictureOwnerType, picture.PictureOwnerType);

                //Updating
                picture.Url = "http://www.stories.com";
                await pictureRespository.Update(picture);
                var updatePicture = await pictureRespository.Get(picture.Id);
                Assert.AreEqual(updatePicture.Url, picture.Url);
                Assert.AreEqual(updatePicture.PictureOwnerType, picture.PictureOwnerType);

                ////Removing
                await pictureRespository.Remove(picture);
                var resultPhoto = pictureRespository.Get(picture.Id).Result;
                Assert.AreEqual(resultPhoto, null);
            }
        }
    }
}
