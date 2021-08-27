using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Stories.Data.Queries;
using Stories.Domain.Model;
using Stories.Utility;


namespace Stories.Application
{
    public class AuthenticateApplication : IAuthenticateApplication
    {

        private string _key = "";
        public AuthenticateApplication()
        {
            _key = "pintusharmaqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqweqwe";
        }
        
        public PersonalInfo Authenticate(string loginId, string encryptedpassword)
        {
            PersonalInfoQuery personalInfoQuery = new PersonalInfoQuery();
            var personalInfo = personalInfoQuery.GetForLogin(loginId, encryptedpassword);
            var personInfo = personalInfo.Result;

            //return null if  user is not found
            if (personInfo == null)
                return null;

            //if user found
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_key);
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

            return personInfo;
        }
    }
    
}
