﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blog.Application.DTOs.Account
{
    public abstract class LoginDto
    {
        
        [Required(ErrorMessage = "Email is required")]
        public  string Email { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        public  string Password { get; set; }
        [JsonConstructor]
        public LoginDto(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
