using Stories.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Application
{
   public interface IAuthenticateApplication
    {
        PersonalInfoModel Authenticate(string userName, string password);
    }
}
