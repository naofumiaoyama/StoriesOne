using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stories.Api.Model;

namespace Stories.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
       

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            List<User> users = new List<User>();
            User user = new User();
            user.PersonInfo = new PersonInfo();
            user.Address = new Address();
            
            user.LoginID = "testID";
            user.DisplayName = "Naofumi Aoyama";
            users.Add(user);
            return users.ToArray();
        }
    }
}