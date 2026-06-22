using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Sensly.Core.Domain.Entities;
using Sensly.Core.DTO;

namespace Sensly.Core.Mappings
{
    public static class UserMapper
    {
        public static User ToEntity(RegisterUserDto dto)
        {
            // IMPLEMENT LATER IF NEEDED
            return new User(); 
        }
    }
}
