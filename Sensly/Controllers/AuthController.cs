
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sensly.Core.Domain.Entities;
using Sensly.Core.DTO;
using Sensly.Core.ServiceContracts.Authentication;
using Sensly.Infrastructure.DatabaseContext;

namespace Sensly.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly ApplicationDbContext _context; 
        public AuthController(IJwtTokenGenerator jwtTokenGenerator, ApplicationDbContext context)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDto dto)
        {

            User user = await _context.Users.FirstOrDefaultAsync(user => user.UserName == dto.UserName);
            if (user is null)
                return Unauthorized();
            return Ok(_jwtTokenGenerator.GenerateAccessToken(user)); 
        }
    }
}
