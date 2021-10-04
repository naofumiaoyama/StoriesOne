using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stories.Data.Queries;
using Stories.Domain.Model;

namespace Stories.Application
{
    public class UserApplication
    {
        private UserQuery _userQuery;
        private FriendQuery _friendQuery;

        public UserApplication()
        {
            _userQuery = new UserQuery();
            _friendQuery = new FriendQuery();
        }

        public async Task<User> GetUserWithFriends(string id)
        {
            var user = await _userQuery.Get(Guid.Parse(id));
            if (user != null)
            {
                var friends = await _friendQuery.Get(Guid.Parse(id));
                user.Friends = friends;
            }
            return user;
        }
        
       
    }
}
