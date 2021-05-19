using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stories.Domain.Model;

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
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            List<User> users = new List<User>();
            User user = new User();
            user.PersonInfo = new PersonInfo();
            user.PersonInfo.Address = (new Address { City = "Ikebukuro", Country = "Japan", Others = "池袋", Street = "" });
            user.LoginID = "testID";
            user.DisplayName = "Naofumi Aoyama";
            users.Add(user);
            var result = await Task.Run(() => users);
            return result;
        }

        [HttpGet("{guid}")]
        public async Task<ActionResult<User>> GetUserByGuid(Guid guid)
        {
            List<User> users = new List<User>();
            User user = new User();
            user.ID = Guid.Parse("430c4bbd-6614-4b17-8bfe-7090ad2ba482");
            user.PersonInfo = new PersonInfo();
            user.PersonInfo.Address = (new Address { City = "Ikebukuro", Country = "Japan", Others = "池袋", Street = "" });
            user.LoginID = "testID";
            user.DisplayName = "Naofumi Aoyama";
            users.Add(user);

            User user1 = new User();
            user1.ID = Guid.Parse("f4caeef7-2158-409b-9534-adf900ae3c89");
            user1.PersonInfo = new PersonInfo();
            user1.PersonInfo.Address = (new Address { City = "Warabi", Country = "Japan", Others = "蕨", Street = "" });
            user1.LoginID = "testID";
            user1.DisplayName = "Toya Arai";
            users.Add(user1);

            var userResults = await Task.Run(() => users);
            var result = userResults.Find(p => p.ID == guid);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            List<User> users = new List<User>();
            User user = new User();
            user.ID = Guid.Parse("430c4bbd-6614-4b17-8bfe-7090ad2ba482");
            user.PersonInfo = new PersonInfo();
            user.PersonInfo.Address = (new Address { City = "Ikebukuro", Country = "Japan", Others = "池袋", Street = "" });
            user.LoginID = "testID";
            user.DisplayName = "Naofumi Aoyama";
            users.Add(user);

            User user1 = new User();
            user1.ID = Guid.Parse("f4caeef7-2158-409b-9534-adf900ae3c89");
            user1.PersonInfo = new PersonInfo();
            user1.PersonInfo.Address = (new Address { City = "Warabi", Country = "Japan", Others = "蕨", Street = "" });
            user1.LoginID = "testID2";
            user1.DisplayName = "Naofumi Aoyama2";
            users.Add(user1);
            var userResults = await Task.Run(() => users);
            var result = userResults.Find(p => p.LoginID == id);
            return result;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(Guid guid, User newUser)
        {
            if (guid != newUser.ID)
            {
                return BadRequest();
            }

            var resultUser = new User();
            //var resultUser = await _context.User.FindAsync(guid);
            //if (resultUser == null)
            //{
            //    return NotFound();
            //}

            //resultUser.FirstName = newUser.FirstName;
            //resultUser.FamiliyName = newUser.FamiliyName;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException) when (!UserExists(id))
            //{
            //    return NotFound();
            //}

            return NoContent();
        }

        [HttpPost]
        public ActionResult<User> CreateUser(User newUser)
        {
            var resultUser = new User
            {
            DisplayName = newUser.DisplayName,
            FamilyName = newUser.FamilyName
            };

           // _context.User.Add(newUser);
            //await _context.SaveChangesAsync();

            return newUser;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid guid)
        {
            //var todoItem = await _context.TodoItems.FindAsync(guid);

            //if (todoItem == null)
            //{
            //    return NotFound();
            //}

            //_context.TodoItems.Remove(User);
            //await _context.SaveChangesAsync();
            var resultUser = new User();


            return NoContent();
        }

        //private bool UserExists(string id) =>
             //_context.TodoItems.Any(e => e.Id == id);

        private static User ItemToDTO(User newUser) =>
            new User
            {
                DisplayName = newUser.DisplayName,
                FamilyName = newUser.FamilyName
            };
    }
}