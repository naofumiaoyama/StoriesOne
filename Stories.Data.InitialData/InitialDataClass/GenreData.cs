using Stories.Data.Entities;
using Stories.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stories.Data.InitialData.InitialDataClass
{
    public class GenreData
    {
        public async Task MakeData()
        {
            using (var context = new DatabaseContext())
            {
                GenericRepository<Genre> genreRepository = new GenericRepository<Genre>(context);
                Genre genre = new Genre();
                genre.Id = Guid.Parse("A130CB16-4349-48DB-9E10-764974E4102D");
                genre.Name = "Horror";
                genre.GenreType = GenreType.Content;
                genre.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                genre.CreateDate = DateTime.Now;
                genre.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                genre.UpdateDate = DateTime.Now;
                await genreRepository.Add(genre);

                Genre genre2 = new Genre();
                genre2.Id = Guid.Parse("7222231D-7EF9-490B-9548-6D6C161F2329");
                genre2.Name = "Comic";
                genre2.GenreType = GenreType.Media;
                genre2.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                genre2.CreateDate = DateTime.Now;
                genre2.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                genre2.UpdateDate = DateTime.Now;
                await genreRepository.Add(genre2);

                Genre genre3 = new Genre();
                genre3.Id = Guid.Parse("64a25e25-2d0b-46e6-8488-dc089bb9a92e");
                genre3.Name = "SF";
                genre3.GenreType = GenreType.Media;
                genre3.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                genre3.CreateDate = DateTime.Now;
                genre3.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                genre3.UpdateDate = DateTime.Now;
                await genreRepository.Add(genre3);
            }
        }

        public async Task DeleteData()
        {
            using (var context = new DatabaseContext())
            {
                GenericRepository<Genre> genreRepository = new GenericRepository<Genre>(context);
                var genre1 = genreRepository.Get(Guid.Parse("A130CB16-4349-48DB-9E10-764974E4102D")).Result;
                if (genre1 != null) { await genreRepository.Remove(genre1); }

                var genre2 = genreRepository.Get(Guid.Parse("7222231D-7EF9-490B-9548-6D6C161F2329")).Result;
                if (genre2 != null) { await genreRepository.Remove(genre2); }

                var genre3 = genreRepository.Get(Guid.Parse("64a25e25-2d0b-46e6-8488-dc089bb9a92e")).Result;
                if (genre3 != null) { await genreRepository.Remove(genre3); }
            }
        }
    }
}
