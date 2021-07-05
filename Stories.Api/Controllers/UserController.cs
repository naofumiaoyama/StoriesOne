using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stories.Domain.Model;
using Stories.Domain.Logic;
using Stories.Data.Queries;
using Stories.Data.Repositories;
namespace Stories.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private UserQuery _userQuery;
        private FriendQuery _friendQuery;
        private UserLogic _userLogic;
       

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
            _userQuery = new UserQuery();
            _friendQuery = new FriendQuery();
            _userLogic = new UserLogic();

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            var user = await _userQuery.Get(Guid.Parse(id));
            var friends = await _friendQuery.Get(Guid.Parse(id));
            return _userLogic.SetFriends(user, friends);
        }

        [HttpPost]
        public async Task CreateUser(string firstName, string lastName, string emailAddress)
        {
            var newUser = new User
            {
                FirstName = firstName,
                LastName = lastName,
                PersonalInfo = new PersonalInfo
                {
                    EmailAddress1 = emailAddress
                }
            };

            
        }


        [HttpPut("{id}")]
        public IActionResult UpdateUser(Guid guid, User newUser)
        {
            if (guid != newUser.Id)
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
                LastName = newUser.LastName
            };
    }
}