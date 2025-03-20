using IdentityTest_3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prj_Ban_Quan_Ao.Models;

namespace IdentityTest_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(Account user)
        {
            if(await _authService.RegisterUser(user))
            {
                return Ok("Đăng ký thành công");
            }
            return BadRequest("Có lỗi xảy ra, hãy thử lại sau");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(Account user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _authService.Login(user);
            if(result)
            {
                var tokenString = _authService.GenerateTokenString(user);
                return Ok(tokenString);
            }
            return BadRequest();
        }
    }
}
