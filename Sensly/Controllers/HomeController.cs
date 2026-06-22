using Microsoft.AspNetCore.Mvc;
using Sensly.Core.DTO;
using Sensly.Core.ServiceContracts;

namespace Sensly.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUserService _userService; 
        public HomeController(IUserService userService)
        {
            _userService = userService; 
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterUserDto dto)
        {   
            await _userService.RegisterUserAsync(dto); 
            return Ok();
        }
    }
}
