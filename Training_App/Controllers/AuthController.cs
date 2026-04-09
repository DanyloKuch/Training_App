using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Training_App.Application.Contracts;
using Training_App.Application.Interfaces;
using Training_App.Domain.Models;

namespace Training_App.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public  AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserRequest userRequest)
        {
            var result = await _authService.Register(userRequest);
            if (result.IsFailure) return BadRequest(result.Error);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserRequest userRequest)
        {
            var result = await _authService.Login(userRequest);
            if (result.IsFailure) return BadRequest(result.Error);
            return Ok(result.Value);   
        }
        
        
    }
}
