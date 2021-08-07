using System;
namespace Stories.Domain.Model
{
    public class ReactionMarkModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ReactionMarkType ReactionMarkType { get; set; }
        public bool Clicked { get; set; }
    }

    public enum ReactionMarkType
    {
        GoodButton = 1,
    }
}
