
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Sensly.Core.Domain.Entities;
using Sensly.Core.DTO;
using Sensly.Core.ServiceContracts;
using Sensly.Core.ServiceContracts.Authentication;
using Sensly.Core.ServiceContracts.Security;
using Sensly.Infrastructure.DatabaseContext;

namespace Sensly.UI.Controllers
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

        [HttpPost("/login")]

        public async Task<IActionResult> Login(LoginUserDto dto)
        {
            string? token = await _authService.LoginAsync(dto);
            if (token is null)
                return Unauthorized("Password or Username Invalid");
            return Ok(token);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDto dto )
        {
            string? token = await _authService.RegisterAsync(dto);
            if (token is null)
                return BadRequest("User Already Exists");
            return Ok(token);
        }
    }
}
