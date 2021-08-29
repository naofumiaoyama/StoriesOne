using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Domain.Model
{
   public class Genre
   {
        public Genre(Guid id, string name, GenreType genreType)
        {
            if (Guid.Empty == id)
            {
                throw new ArgumentException("id is a required field.");
            }
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("name is a required field");
            }
            if (!GenreType.IsDefined(genreType))
            {
                throw new ArgumentException("The genreType has not been defined");
            }
            Id = id;
            Name = name;
            this.GenreType = genreType;
        }
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public GenreType GenreType { get; private set; }
   }

    public enum GenreType
    {
        Media = 1,
        Content = 2
    }
}
