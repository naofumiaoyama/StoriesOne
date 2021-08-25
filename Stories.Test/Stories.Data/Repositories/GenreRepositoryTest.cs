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
   public class GenreRepositoryTest
    {
        [TestMethod]
        public async Task CRUDTest()
        {
            using (var context = new DatabaseContext())
            {
                GenericRepository<Genre> genreRepository = new GenericRepository<Genre>(context);
                //adding
                Genre genre = new Genre();
                genre.Id = Guid.Parse("E3DAF3D4-4B91-491F-A71D-24AE551FB321");
                genre.Name = "Fantasy";
                genre.GenreType = GenreType.Content;
                genre.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                genre.CreateDate = DateTime.Now;
                genre.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                genre.UpdateDate = DateTime.Now;
                await genreRepository.Add(genre);

                //getting
                var getGenre = genreRepository.Get(genre.Id).Result;

                Assert.AreEqual(getGenre.Id, genre.Id);
                Assert.AreEqual(getGenre.Name, genre.Name);
                Assert.AreEqual(getGenre.GenreType, genre.GenreType);


                //updating
                genre.Name = "Comic";
                genre.GenreType = GenreType.Media;
                await genreRepository.Update(genre);
                var updategenre = await genreRepository.Get(genre.Id);
                Assert.AreEqual(updategenre.Id, genre.Id);
                Assert.AreEqual(updategenre.Id, genre.Id);
                Assert.AreEqual(updategenre.Name, genre.Name);
                Assert.AreEqual(updategenre.GenreType, genre.GenreType);

                //Removing
               await genreRepository.Remove(genre);
                var resultgenre = genreRepository.Get(genre.Id).Result;
               Assert.AreEqual(resultgenre, null);
            }
        }
    }
}
