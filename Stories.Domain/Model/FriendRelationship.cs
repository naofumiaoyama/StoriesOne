using System;
namespace Stories.Domain.Model

{
  public  class FriendRelationship
    {   
        public Guid PersonId { get; set; }
        public Guid FriendPersonId { get; set; }
        public DateTime FriendshipDateTime { get; set; }
    }
}
