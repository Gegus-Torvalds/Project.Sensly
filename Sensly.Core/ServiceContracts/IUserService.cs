using Sensly.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sensly.Core.ServiceContracts
{
    public interface IUserService
    {
        public Task RegisterUserAsync(RegisterUserDto dto);
    }
}
