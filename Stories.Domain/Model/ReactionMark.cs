using System;
namespace Stories.Domain.Model
{
    public class ReactionMark
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public ReactionMarkType ReactionMarkType { get; set; }
        public bool Clicked { get; set; }
    }

    public enum ReactionMarkType
    {
        GoodButton = 1,
    }
}
