using System;
using System.Collections.Generic;
using System.Text;

namespace Sensly.Core.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>(); 
    }
}
