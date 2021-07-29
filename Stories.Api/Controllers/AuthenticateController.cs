using Microsoft.AspNetCore.Mvc;
using Stories.Application;
using Stories.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Stories.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private IAuthenticateApplication _authenticateApplication;
        public AuthenticateController(IAuthenticateApplication authenticateApplication)
        {
            _authenticateApplication = authenticateApplication;
        }
        [HttpPost]
        public IActionResult Post(string loginId, string encryptedPassword)
        {
            var personInfo = _authenticateApplication.Authenticate(loginId, encryptedPassword);

            if (personInfo == null)
                return BadRequest(new { message = "LoginID or Password is incorrect" });

            return Ok(personInfo);
        }
    }
}
