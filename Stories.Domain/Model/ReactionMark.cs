using System;
namespace Stories.Domain.Model
{
    public class ReactionMark
    {
        public ReactionMark(Guid id, string name, string url, ReactionMarkType reactionMarkType, bool clicked)
        {
            if (Guid.Empty == id)
            {
                throw new ArgumentException("id is a required field.");
            }
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("name is a required field");
            }
            if(string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("url is a required field");
            }
            if(!ReactionMarkType.IsDefined(reactionMarkType))
            {
                throw new ArgumentException("The reactionMarkType has not been defined");
            }
            this.Id = id;
            this.Name = name;
            this.Url = url;
            this.ReactionMarkType = reactionMarkType;
            this.Clicked = clicked;
        }


        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Url { get; private set; }
        public ReactionMarkType ReactionMarkType { get; private set; }
        public bool Clicked { get; private set; }
    }

    public enum ReactionMarkType
    {
        GoodButton = 1,
    }
}
