using Sensly.Core.Domain.Entities;
using Sensly.Core.Domain.RepositoryContracts;
using Sensly.Core.DTO;
using Sensly.Core.ServiceContracts;
using Sensly.Core.ServiceContracts.Authentication;
using Sensly.Core.ServiceContracts.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sensly.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository; 
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }
        public async Task<string?> LoginAsync(LoginUserDto dto)
        {
            User user = await _userRepository.GetUserByUsernameAsync(dto.UserName);

            if (user is null || !(_passwordHasher.VerifyPassword(dto.Password, user.PasswordHash)))
                return null;

            return _jwtTokenGenerator.GenerateAccessToken(user); 


        }
        public async Task<string?> RegisterAsync(RegisterUserDto dto)
        {
            User? existingUser = await _userRepository.GetUserByUsernameAsync(dto.UserName);
            if (existingUser is not null)
                return null;
            User user = new User()
            {
                UserName = dto.UserName,
                PasswordHash = _passwordHasher.HashPassword(dto.Password)
            }; 
            await _userRepository.AddAsync(user);

            return _jwtTokenGenerator.GenerateAccessToken(user);
        }

        public Task LogoutAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<string?> RefreshTokenAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }

    }
}
