using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StreamLineModels;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.API.Services
{
    public class UserService : IUserService
    {
        private readonly IcecapContext _context;
        private readonly IConfiguration _configuration;

        public UserService(IcecapContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<Models.SecurityToken> Authenticate(string username, string password)
        {
            var user = await _context.TblPersondetails.SingleOrDefaultAsync(x => x.Username == username && x.Pwd == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["TokenSecret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(AppClaimTypes.PersonId, user.Id.ToString()),
                    new Claim(AppClaimTypes.GivenName, user.GivenName),
                    new Claim(AppClaimTypes.MiddleName, user.MiddleName),
                    new Claim(AppClaimTypes.FamilyName, user.FamilyName),
                    new Claim(AppClaimTypes.PrivId, user.PrivId.ToString()),
                    new Claim(AppClaimTypes.Active, user.Active.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtSecurityToken = tokenHandler.WriteToken(token);

            return new Models.SecurityToken() { auth_token = jwtSecurityToken };
        }

        public async Task<Models.SecurityToken> AuthenticatePatient(string username, string password)
        {
            var patient = await _context.TblPatient.SingleOrDefaultAsync(x => x.EcrfNo == username && x.Pwd == password);

            // return null if user not found
            if (patient == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["TokenSecret2"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(AppClaimTypes.EcrfNo, patient.EcrfNo),
                    new Claim(AppClaimTypes.NumTimesLogged, patient.NumTimesLogged.ToString()),
                    new Claim(AppClaimTypes.Nurse, patient.Nurse),
                    new Claim(AppClaimTypes.NurseEmail, patient.NurseEmail),
                    new Claim(AppClaimTypes.Notes, patient.Notes),
                    new Claim(AppClaimTypes.AccessLevel, "3")
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtSecurityToken = tokenHandler.WriteToken(token);

            return new Models.SecurityToken() { auth_token = jwtSecurityToken };
        }
    }
}