using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Domain.Model
{
    public class Character
    {
        public Character(Guid id, string name, string content)
        {
            if (Guid.Empty == id)
            {
                throw new ArgumentException("id is a required field.");
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("name is a required field.");
            }
            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentException("content is a required field.");
            }
            this.Id = id;
            this.Name = name;
            this.Content = content;
        }
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Content { get; private set; }
    }
}
