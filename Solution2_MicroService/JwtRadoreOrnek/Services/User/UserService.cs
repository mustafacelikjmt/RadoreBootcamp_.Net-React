using JwtRadoreOrnek.Entities;
using JwtRadoreOrnek.Helpers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtRadoreOrnek.Services.User
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly ApplicationDbContext _dbContext;

        public UserService(AppSettings appSettings, ApplicationDbContext applicationDbContext)
        {
            _appSettings = appSettings;
            _dbContext = applicationDbContext;
        }

        public (string userName, string token)? Authenticate(string userName, string password)
        {
            var user = _dbContext.ApplicationUser.SingleOrDefault(x => x.UserName == userName && x.Password == password);
            if (user == null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor() //tokeni olan kullanıcı için çalışır
            {
                Subject = new ClaimsIdentity(new[] {
                new Claim("userId", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            string generatadToken = tokenHandler.WriteToken(token);

            return (user.UserName, generatadToken);
        }
    }
}