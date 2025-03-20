using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Prj_Ban_Quan_Ao.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityTest_3.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<bool> RegisterUser(Account user)
        {
            var identityUser = new IdentityUser
            {
                UserName = user.TenDangNhap,
                Email = user.TenDangNhap
            };
            var result = await _userManager.CreateAsync(identityUser, user.MatKhau);
            return result.Succeeded;
        }

        public async Task<bool> Login(Account user)
        {
            var identityUser = await _userManager.FindByEmailAsync(user.TenDangNhap);
            if(identityUser == null)
            {
                return false;
            }
            return await _userManager.CheckPasswordAsync(identityUser, user.MatKhau);
        }

        public string GenerateTokenString(Account user)
        {
            IEnumerable<System.Security.Claims.Claim> claims = new List<Claim> 
            { 
                new Claim(ClaimTypes.Email, user.TenDangNhap),
                new Claim(ClaimTypes.Role, "Admin")
            };

            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));

            SigningCredentials signingCred = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256Signature);

            SecurityToken securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                issuer: _configuration.GetSection("Jwt:Issuer").Value,
                audience: _configuration.GetSection("Jwt:Audience").Value,
                signingCredentials: signingCred
                );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return tokenString;
        }
    }
}
