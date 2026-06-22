using System;
using System.Collections.Generic;
using System.Text;

namespace Sensly.Core.Domain.Entities
{
    public class UserRole
    {
        public Guid RoleId { get; set; } 
        public Role Role { get; set; } 
        public Guid UserId { get; set; } 
        public User User { get; set; } 
    }
}
