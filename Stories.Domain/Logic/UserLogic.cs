using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stories.Domain.Model;

namespace Stories.Domain.Logic
{
    public class UserLogic
    {
        public User SetFriends(User user, IDictionary<Guid, User> friends)
        {
            if(friends == null)
            {
                System.Diagnostics.Debug.WriteLine("There's no friends now");
            }
            user.Friends = friends;
            return user;
        }

        public User CheckSignUpUser(User user)
        {
            if(user.PersonalInfo.EmailAddress1 == null)
            {
                System.Diagnostics.Debug.WriteLine("There's no friends now");
            }
            return user;
        }
    }
}
