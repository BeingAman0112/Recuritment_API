using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recruitment.Core.DTO;
using Recuritment.Application.IServices;

namespace Recruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginSignUpController : ControllerBase
    {
        private readonly IUserService _user;

        public LoginSignUpController(IUserService authService)
        {
            _user = authService;
        }

        // ✅ SignUp endpoint
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] UserSignupDto request)
        {
            var result = await _user.SignUp(request);
            if (result == "User already exists")
                return BadRequest(new { message = result });

            return Ok(new { message = result });
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto request)
        {
            var token = await _user.Login(request.Email, request.Password);

            if (token == null)
                return Unauthorized(new { message = "Invalid email or password" });

            return Ok(new { token });
        }


    }
}
