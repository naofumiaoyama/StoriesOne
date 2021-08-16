using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Domain.Model
{
    public class Character
    {
        public Character(Guid id, string name, string description)
        {
            if (Guid.Empty == id)
            {
                throw new ArgumentException("id is a required field.");
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("name is a required field.");
            }
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentException("description is a required field.");
            }
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
