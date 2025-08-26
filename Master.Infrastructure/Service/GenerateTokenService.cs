
using LOSApplicationApi.Data;
using LOSApplicationApi.DTO;
using LOSApplicationApi.Repository;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LOSApplicationApi.Service
{
    public class GenerateTokenService: IToken
    {
        ApplicationDbContext db;
        IConfiguration configuration;
        public GenerateTokenService(ApplicationDbContext db, IConfiguration configuration) {
            this.db = db;
            this.configuration = configuration;
        }

        public string GenerateToken(LoginDTO details )
        {
            var cfg = configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(cfg["SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var roleName = db.UserRole
                .Include(ur => ur.User)
                .Include(ur => ur.Role)
                .Where(ur => ur.User.UserName == details.UserName || ur.User.Email==details.UserName) // if 'token' holds the username
                .Select(ur => ur.Role)
                .FirstOrDefault();
            if (roleName == null)
            {
                return null; // Or throw an exception if appropriate
            }


            var claims = new List<Claim>
                {
                new Claim(JwtRegisteredClaimNames.Sub, details.UserName),
                new Claim(ClaimTypes.Role, roleName.RoleName), // assuming RoleName is the name
                new Claim("CustomData", details.PasswordHash)
            };

            // Create the JWT token
            var token = new JwtSecurityToken(
                issuer: cfg["Issuer"],
                audience: cfg["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }   
    }
}
