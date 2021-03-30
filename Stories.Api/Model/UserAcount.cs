using System;
using Microsoft.AspNetCore.Http;
namespace Stories.Api.Model
{
    public class UserAccount
    {
        public string UserName { get; set; }
        private IFormFile[] Images { get; set; }
    }
}
