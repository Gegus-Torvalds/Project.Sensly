using System;
using System.Collections.Generic;
using System.Text;

namespace Sensly.Core.ServiceContracts.Security
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);

        bool VerifyPassword(string password, string hashedPassword); 
    }
}
