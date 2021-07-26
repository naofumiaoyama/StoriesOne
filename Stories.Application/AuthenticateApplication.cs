using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Stories.Domain.Model;
using Stories.Utility;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Stories.Data.Queries;


namespace Stories.Application
{
    public class AuthenticateApplication : IAuthenticateApplication
    {
    
        private readonly AppSettings _appSettings;
        public AuthenticateApplication(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        
        public PersonalInfo Authenticate(string loginId, string password)
        {

            LoginQuery loginQuery = new LoginQuery();
            var personalInfo = loginQuery.Get(loginId, password);
            var personInfo = personalInfo.Result;

            //return null if  user is not found
            if (personInfo == null)
                return null;

            //if user found
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                  new Claim(ClaimTypes.Email, personInfo.EmailAddress1),
                  new Claim(ClaimTypes.Role, "Admin"),
                  new Claim(ClaimTypes.Version, "V3.1")
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            personInfo.Token = tokenHandler.WriteToken(token);

            personInfo.Password = null;

            return personInfo;
        }
    }
    
}
