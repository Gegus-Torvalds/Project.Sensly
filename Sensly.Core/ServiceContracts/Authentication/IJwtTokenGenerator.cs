using Sensly.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sensly.Core.ServiceContracts.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateAccessToken(User user);
        string GenerateRefreshToken();
    }
}
