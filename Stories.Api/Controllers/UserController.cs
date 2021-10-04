using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Stories.Domain.Model;
using Stories.Application;

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

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>>  GetUserWithFriendsAsync(string id)
        {
            UserApplication userApplication = new UserApplication();
            var user = await userApplication.GetUserWithFriends(id);
            return (user == null)
                ? NotFound()
                : Ok(user);
        }

    }
}