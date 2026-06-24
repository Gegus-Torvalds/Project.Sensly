using Sensly.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sensly.Core.ServiceContracts
{
    public interface IAuthService
    {
        Task<string?> LoginAsync(LoginUserDto dto);
        Task<string?> RegisterAsync(RegisterUserDto dto);
        Task<string?> RefreshTokenAsync(string refreshToken);
        Task LogoutAsync(string refreshToken); 
    }
}
