using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 


namespace Stories.Data.Entities
{
    public class FriendRelationshipEntity : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public string FullName { get; set; }
        [ForeignKey("Person")]
        public Guid FriendPersonId { get; set; }
        public string FriendFullName { get; set; }
        public DateTime FriendshipDateTime { get; set; }
  }
}
