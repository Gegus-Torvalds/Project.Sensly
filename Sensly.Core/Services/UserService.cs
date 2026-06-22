using Sensly.Core.Domain.Entities;
using Sensly.Core.Domain.RepositoryContracts;
using Sensly.Core.DTO;
using Sensly.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sensly.Core.Services
{
    public class UserService: IUserService
    {

        private readonly IUserRepository _userRepository; 
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository; 
        }
       
        public async Task RegisterUserAsync(RegisterUserDto dto)
            {
                var user = new User()
                {
                    UserName = dto.UserName,
                    PasswordHash = dto.Password
                };

            await _userRepository.AddAsync(user);
            

            }
    }
}
