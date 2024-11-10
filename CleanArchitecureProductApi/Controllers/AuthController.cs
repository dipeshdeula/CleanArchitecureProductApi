using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Application.DTOs;
using ProductApi.Infrastructure.Services;
using ProductApi.Infrastructure.Utilities;

namespace CleanArchitecureProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtTokenHelper _jwtTokenHelper;

        public AuthController(IUserService userService, JwtTokenHelper jwtTokenHelper)
        {
            _userService = userService;
            _jwtTokenHelper = jwtTokenHelper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            var user = await _userService.AuthenticateAsync(loginDto.Username, loginDto.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            var token = _jwtTokenHelper.GenerateToken(user);
            return Ok(new { token });
        }

    }
}
