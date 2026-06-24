using Sensly.Core.ServiceContracts.Security;
using System;
using System.Collections.Generic;
using System.Text;
using BCrypt.Net;
namespace Sensly.Infrastructure.Security
{
    internal class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword); 
        }
    }
}
