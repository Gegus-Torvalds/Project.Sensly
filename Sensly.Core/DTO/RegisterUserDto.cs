using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sensly.Core.DTO
{
    public class RegisterUserDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match!")]
        public string ConfirmPassword { get; set; } 
        
    }
}
